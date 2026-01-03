using UnityEngine;

public class EnemyBoss : Enemy
{
    [SerializeField] private float _firstValue;
    [SerializeField] private float _secondValue;
    [SerializeField] private float _thirtValue;
    [SerializeField] private float _forthValue;
    [SerializeField] private float _fifthValue;
    [SerializeField] private float _sixValue;
    [SerializeField] private float _sevenValue;
    [SerializeField] private float _spawnEnemies;
    [SerializeField] private float _bullets;
    [SerializeField] private EnemyBossAnimator _animator;

    private float _currentBulletCount;
    private EnemySpawner _spawner;
    private LootSpawner _lootSpawner;

    protected override void Awake()
    {
        base.Awake();
        _spawner = FindFirstObjectByType<EnemySpawner>();
        _lootSpawner = FindFirstObjectByType<LootSpawner>();
    }

    protected override void OnHealthChanged(float value)
    {
        base.OnHealthChanged(value);

        if (value < _firstValue)
        {
            _firstValue = float.MinValue;
            SpawnEnemies(10, _spawner.SpawnEnemy);
            return;
        }

        if (value < _secondValue)
        {
            _secondValue = float.MinValue;
            SpawnEnemies(10, _spawner.SpawnMonsterEnemy);
            return;
        }
        
        if (value < _thirtValue)
        {
            _thirtValue = float.MinValue;
            SpawnEnemies(10, _spawner.SpawnSpeedy);
            return;
        }


        if (value < _forthValue)
        {
            _forthValue = float.MinValue;
            SpawnEnemies(5, _spawner.SpawnMonsterSpeedy);
            return;
        }
        
        if (value < _fifthValue)
        {
            _fifthValue = float.MinValue;
            SpawnEnemies(5, _spawner.SpawnMonsterSpeedy);
            return;
        }
       
        if (value < _sixValue)
        {
            _sixValue = float.MinValue;
            SpawnEnemies(5, _spawner.SpawnHamer);
            return;
        }

        if (value < _sevenValue)
        {
            _sevenValue = float.MinValue;

            for (int i = 0; i < 5; i++)
            {
                Enemy enemy = _spawner.SpawnAngryHamer(transform.position);
                Enemy enemy1 = _spawner.SpawnEnemy(transform.position);
                Enemy enemy2 = _spawner.SpawnSpeedy(transform.position);
                Subcrible(enemy);
                Subcrible(enemy1);
                Subcrible(enemy2);
            }

            return;
        }

        if (_currentBulletCount < _bullets)
        {
            SpawnEnemies(1, _spawner.SpawnEnemy);
        }
    }

    private void SpawnEnemies(int count, System.Func<Vector3, Enemy> spawnFunc)
    {
        for (int i = 0; i < count; ++i)
        {
            Enemy enemy = spawnFunc(transform.position);
            Subcrible(enemy);
        }
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _lootSpawner.SpawnBulletBag(enemy.transform.position);
        enemy.Died -= OnEnemyDied;
    }

    private void Subcrible(Enemy enemy)
    {
        enemy.Died += OnEnemyDied;
    }

    public void UpdateBulletCount(float _current)
    {
        _currentBulletCount = _current;
    }

    protected override void ProcessDied()
    {
        SfxPlayer.Instance.PlayDieBossSound();
        _animator.PlayDied();
        Invoke(nameof(DestroyBoss), 3f);
    }
    
    private void DestroyBoss() =>
        Destroy(gameObject);
}