using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageble
{
    private const float StoppingDistance = 0.5f;

    [SerializeField] private AttackDetector _attackDetector;
    [SerializeField] private Health _health;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _speed;
    [SerializeField] private float _detectionRadius;
    [SerializeField] private float _damageAmount;
    [SerializeField] private float _frost;
    [SerializeField] private float _attackRate = 1f;
    [SerializeField] private int _scoreReward;
    [SerializeField] private float _currentSpeed;
    [SerializeField] private Material _defultSkin;
    [SerializeField] private Material _frostSkin;
    [SerializeField] private Material _poisonSkin;
    [SerializeField] private Material _minionSkin;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private float _slowDelay;

    protected Health HealthComponent => _health;
    private Coroutine _fricklesCoroutine;
    private bool _isPoison;
    private bool _isSlowed;
    private float _elapsedTime;
    private Player _player;
    private bool _isFrozen;
    private bool _isMinion;

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

    protected virtual void Update()
    {
        if (_isFrozen)
            return;

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


    public virtual void TakeDamage(float value)
    {
        _health.TakeDamage(value);
    }

    public void Freeze()
    {
        _isFrozen = true;
        _agent.speed = 0f;
    }

    public void ResetFreezen()
    {
        _isFrozen = false;
        _agent.speed = _currentSpeed;
    }

    protected virtual void Attack(Player player)
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
        _renderer.material = _defultSkin;
        SfxPlayer.Instance.PlayDieEnemySound();
        ParticleSpawner.Instance.CreateBlood(transform.position);
        Destroy(gameObject);
    }

    public void ReplaceSkin()
    {
        _isMinion = true;
        _renderer.material = _minionSkin;
    }

    public void ApplaySlow()
    {
        if (_isSlowed)
            return;

        _isSlowed = true;
        _agent.speed *= 0.5f;
        _renderer.material = _frostSkin;

        SfxPlayer.Instance.PlayFrostSound();
        Invoke(nameof(AfterSlow), _slowDelay);
    }


    public void AfterSlow()
    {
        _agent.speed = _currentSpeed;
        _isSlowed = false;

        if (_isMinion == false)
            _renderer.material = _defultSkin;

        if (_isMinion == true)
            _renderer.material = _minionSkin;
    }

    public void ApplyPoison(float poisonDamage, float duraction, float tickInterval)
    {

        if (_isPoison == true || _isMinion)
            return;

        if (_renderer == null)
        {
            Debug.LogWarning("Enemy not Applay : Render material");
            return;
        }

        _isPoison = true;

        _fricklesCoroutine = StartCoroutine(PoisonCoroutine(poisonDamage, duraction, tickInterval));
    }

    public IEnumerator PoisonCoroutine(float poisonDamage, float duraction, float tickInterval)
    {
        float elapset = 0f;
        WaitForSeconds wait = new(tickInterval);
        bool toogle = false;

        while (elapset < duraction)
        {
            _health.TakeDamage(poisonDamage);
            SfxPlayer.Instance.PlayPoisonSound();

            yield return wait;
            elapset += tickInterval;
            Debug.Log($"{elapset += tickInterval} есть  отровление");
            toogle = !toogle;
            _renderer.material = toogle ? _poisonSkin : _defultSkin;
        }
      
            if (_isMinion == false)
            _renderer.material = _defultSkin;
           
        if (_isMinion == true)
            _renderer.material = _minionSkin;
       
        _renderer.material = _defultSkin;
       _isPoison = false;
       

        if (_fricklesCoroutine != null)
        {
            StopCoroutine(_fricklesCoroutine);
            _fricklesCoroutine = null;
        }
    }

    protected virtual void OnHealthChanged(float value)
    {

    }
}
