using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private const float StoppingDistance = 0.5f;

    [SerializeField] private DistanceDetector _detector;
    [SerializeField] private AttackDetector _attackDetector;
    [SerializeField] private Health _health;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _speed;
    [SerializeField] private float _detectionRadius;
    [SerializeField] private float _damageAmount;
    [SerializeField] private float _attackRate = 1f;
    [SerializeField] private AudioClip _attackSound;

    private float _elapsedTime;
    private Player _player;
    private AudioSource _audioSource;

    public event Action Attacked;
    public event Action<Enemy> Died;

    private void Awake()
    {
        _agent.speed = _speed;
        _agent.stoppingDistance = StoppingDistance;

        if (_audioSource == null)
            _audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _detector.Detected += OnDetected;
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _detector.Detected -= OnDetected;
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

    public void TakeDamage(float value) =>
        _health.TakeDamage(value);

    private void Attack(Player player)
    {
        player.TakeDamage(_damageAmount);

        if (_attackSound != null && _audioSource != null)
            _audioSource.PlayOneShot(_attackSound);

        Attacked?.Invoke();
    }

    private void OnDetected(Player player) =>
        _player = player;
    
    private void OnDied()
    {
        Died?.Invoke(this);
        Destroy(gameObject);
    }
}