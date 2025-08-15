using UnityEngine;

public class BossAbilitiy : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _firstValue;
    [SerializeField] private float _secondValue;
    [SerializeField] private float _thirtValue;
    [SerializeField] private float _forthValue;
    [SerializeField] private float _spawnEnemies;
    [SerializeField] private float _bullets;

    private float _currentBulletCount;
    private EnemySpawner _spawner;
    private LootSpawner _lootSpawner;

    private void Awake()
    {
        _spawner = FindFirstObjectByType<EnemySpawner>();
        _lootSpawner = FindFirstObjectByType<LootSpawner>();
    }

    private void OnEnable() =>
        _health.ValueChanged += OnValueChanged;

    private void OnDisable() =>
        _health.ValueChanged -= OnValueChanged;

    private void OnValueChanged(float value)
    {
        if (value < _firstValue)
        {
            _firstValue = float.MinValue;
            SpawnEnemies(5, _spawner.SpawnEnemy);
            return;
        }

        if (value < _secondValue)
        {
            _secondValue = float.MinValue;
            SpawnEnemies(5, _spawner.SpawnSpeedy);
            return;
        }


        if (value < _thirtValue)
        {
            _thirtValue = float.MinValue;
            SpawnEnemies(5, _spawner.SpawnHamer);
            return;
        }

        if (value < _forthValue)
        {
            _forthValue = float.MinValue;

            for (int i = 0; i < 5; i++)
            {
                Enemy enemy = _spawner.SpawnHamer(transform.position);
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

    public void SpawnEnemies(int count, System.Func<Vector3, Enemy> spawnFunc)
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
}