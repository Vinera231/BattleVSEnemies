using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

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
    [SerializeField] private Material _defultSkin;
    [SerializeField] private Material _frostSkin;
    [SerializeField] private Material _poisonSkin;
    [SerializeField] private Renderer _renderer;

    private Coroutine _poisonCoroutine;
    private Coroutine _fricklesCoroutine;
    private bool _isPoison;
    private bool _isSlowed;
    private float _elapsedTime;
    private Player _player;
    public event Action Attacked;
    public event Action<Enemy> Died;

    public int ScoreReward => _scoreReward;

    protected virtual void Awake()
    {
        _currentSpeed = _speed;
        _agent.speed = _speed;
        _agent.stoppingDistance = StoppingDistance;

        _player = FindFirstObjectByType<Player>();
    }

    protected virtual void OnEnable()
    {
        _health.ValueChanged += OnHealthChanged;
        _health.Died += OnDied;
    }

    protected virtual void OnDisable()
    {
        _health.ValueChanged -= OnHealthChanged;
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

    private void OnDied()
    {
        Died?.Invoke(this);
        ProcessDied();
    }

    protected virtual void ProcessDied()
    {
        SfxPlayer.Instance.PlayDieEnemySound();
        SpawnBloodParticle.Instance?.CreateBlood(transform.position);
        Debug.Log("SpawnBlood.Instance.CreateBlood : был вызван ");
        Destroy(gameObject);
    }

    public void ApplaySlow(float slow, float _slowAmount)
    {
        if (_isSlowed)
            return;

        _isSlowed = true;
        _agent.speed = Mathf.Min(0.3f, _speed, _slowAmount);
        _renderer.material = _frostSkin;

        SfxPlayer.Instance.PlayFrostSound();

        Invoke(nameof(AfterSlow), _slowAmount);
    }

    public void AfterSlow()
    {
        _agent.speed = _currentSpeed;
        _isSlowed = false;
        _renderer.material = _defultSkin;
    }


    public void ApplyPoison(float poisonDamage, float duraction, float tickInterval)
    {
      
        if (_isPoison == true)
            return;

        if(_renderer == null)
        {
            Debug.LogWarning("Enemy not Applay : Render material");
            return;
        }

        _isPoison = true;

        _poisonCoroutine = StartCoroutine(PoisonCoroutine(poisonDamage, duraction, tickInterval));
        _fricklesCoroutine = StartCoroutine(PoisonCoroutine(poisonDamage, duraction, tickInterval));
    }

    public IEnumerator PoisonCoroutine(float poisonDamage, float duraction, float tickInterval)
    {
        float _elapset = 0f;

        while (_elapset < duraction)
        {
            _health.TakeDamage(poisonDamage);
            SfxPlayer.Instance.PlayPoisonSound();

            yield return new WaitForSeconds(tickInterval);
            _elapset += tickInterval;
            Debug.Log("есть  отровление");
            StartCoroutine(FricklerCoroutine(duraction,tickInterval));
        }

        _isPoison = false;

        if(_fricklesCoroutine != null)
        {
            StopCoroutine(_fricklesCoroutine);
            _fricklesCoroutine = null;
        }
              
         if(_renderer != null && _defultSkin != null)
            _renderer.material = _defultSkin;
            
            _poisonCoroutine = null;    
    }

    private IEnumerator FricklerCoroutine(float duraction, float tickInterval)
    {
        float elapsed = 0f;
        bool toogle;

        while (elapsed < duraction && _isPoison)
        {
            toogle =! false;
            _renderer.material = toogle ? _poisonSkin : _defultSkin;
        
            yield return new WaitForSeconds(tickInterval);
            elapsed += tickInterval;
        }

        if (_renderer != null && _defultSkin != null)
            _renderer.material = _defultSkin;

    }

    protected virtual void OnHealthChanged(float value)
    {

    }
}