using UnityEngine;

public class BossAbilitiy : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _firstValue;
    [SerializeField] private float _secondValue;
    [SerializeField] private float _thirtValue;
    [SerializeField] private float _forthValue;

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

            for (int i = 0; i < 5; i++)
            {
                Enemy enemy = _spawner.SpawnEnemy(transform.position);
                enemy.Died += OnEnemyDied;
            }

            return;
        }

        if (value < _secondValue)
        {
            _secondValue = float.MinValue;

            for (int i = 0; i < 10; i++)
            {
                Enemy enemy = _spawner.SpawnSpeedy(transform.position);
                enemy.Died += OnEnemyDied;
            }               

            return;
        }


        if (value < _thirtValue)
        {
            _thirtValue = float.MinValue;

            for (int i = 0; i < 5; i++)
            {
                Enemy enemy = _spawner.SpawnHamer(transform.position);
                enemy.Died += OnEnemyDied;
            }

            return;
        }

        if (value < _forthValue)
        {
            _thirtValue = float.MinValue;

            for (int i = 0; i < 5; i++)
            {
                Enemy enemy = _spawner.SpawnHamer(transform.position);
                Enemy enemy1 = _spawner.SpawnEnemy(transform.position);
                Enemy enemy2 = _spawner.SpawnSpeedy(transform.position);
                enemy.Died += OnEnemyDied;
                enemy1.Died += OnEnemyDied;
                enemy2.Died += OnEnemyDied;
                
            }

            return;
        }

    }

    private void OnEnemyDied(Enemy enemy)
    {
        _lootSpawner.SpawnBulletBag(enemy.transform.position);
        enemy.Died -= OnEnemyDied;
    }
}