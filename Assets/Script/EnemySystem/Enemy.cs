using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy : MonoBehaviour
{
    private const float StoppingDistance = 0.5f;

    [SerializeField] private AttackDetector _attackDetector;
    [SerializeField] private Health _health;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _speed;
    [SerializeField] private float _detectionRadius;
    [SerializeField] private float _damageAmount;
    [SerializeField] private float _attackRate = 1f;
    [SerializeField] private int _scoreReward;
    [SerializeField] private float _currentSpeed;

    private bool _isSlowed;
    private float _elapsedTime;
    private Player _player;

    public event Action Attacked;
    public event Action<Enemy> Died;

    public int ScoreReward => _scoreReward;

    private void Awake()
    {
        _currentSpeed = _speed;
        _agent.speed = _speed;
        _agent.stoppingDistance = StoppingDistance;

        _player = FindFirstObjectByType<Player>();
    }

    private void OnEnable()
    {
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    private void Update()
    {
        if (_agent.isOnNavMesh == false || _player == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);

        if (distanceToPlayer < _detectionRadius)
            _agent.SetDestination(_player.transform.position);

        if (distanceToPlayer > _detectionRadius)
        {
            _agent.ResetPath();
            _player = null;
            return;
        }

        if (_attackDetector.CanAttack == false)
            return;

        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _attackRate)
        {
            _elapsedTime = 0f;
            Attack(_player);
        }
    }

    public enum DamageType
    {
        Default,
        Hammer
    }


    public void TakeDamage(float value)
    {
        _health.TakeDamage(value);

    }
    private void Attack(Player player)
    {
        player.TakeDamage(_damageAmount);

        SfxPlayer.Instance.PlayKickEnemy();
        
        Attacked?.Invoke();
    }

    public void ApplaySlow(float slow,float _slowAmount)
    {
        if (_isSlowed)
            return;

        _isSlowed = true;
        _agent.speed = Mathf.Min(0.3f, _speed,_slowAmount);

        Invoke(nameof(AfterSlow),_slowAmount);
    }

    public void AfterSlow()
    {
        _agent.speed = _currentSpeed;
        _isSlowed = false;
    }
    private void OnDied()
    {
        Died?.Invoke(this);
        Destroy(gameObject);
    }
}