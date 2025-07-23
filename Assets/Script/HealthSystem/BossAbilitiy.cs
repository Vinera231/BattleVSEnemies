using UnityEngine;

public class BossAbilitiy : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _firstValue;
    [SerializeField] private float _secondValue;

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

            for (int i = 0; i < 7; i++)
            {
                Enemy enemy = _spawner.SpawnEnemy(transform.position);
                enemy.Died += OnEnemyDied;
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