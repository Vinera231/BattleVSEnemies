using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private const float StoppingDistance = 0.5f;

    [SerializeField] private DistanceDetector _detector;
    [SerializeField] private Health _health;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _speed;
    [SerializeField] private float _detectionRadius;
    [SerializeField] private float _damageAmount;
    [SerializeField] private AudioClip _attackSound;

    private Transform _target;
    private AudioSource _audioSource;
    public event Action Attacked;

    private void Awake()
    {
        _agent.speed = _speed;
        _agent.stoppingDistance = StoppingDistance;

        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
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
        if (_agent.isOnNavMesh == false || _target == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, _target.position);

        if (distanceToPlayer < _detectionRadius)
            _agent.SetDestination(_target.position);

        if (distanceToPlayer > _detectionRadius)
        {
            _agent.ResetPath();
            Debug.Log("путь потерен");
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerControler player))
            Attack(player);
    }

    public void TakeDamage(float value)
    {
        _health.TakeDamage(value);
    }

    private void Attack(PlayerControler player)
    {
        player.TakeDamage(_damageAmount);

        if (_attackSound != null && _audioSource != null)
        {
            _audioSource.PlayOneShot(_attackSound);
        }

        Attacked?.Invoke();

    }

    private void OnDetected(Transform player)
    {
        _target = player.transform;
        _agent.SetDestination(_target.position);
    }
    
    private void OnDied() =>
        Destroy(gameObject);

  
}