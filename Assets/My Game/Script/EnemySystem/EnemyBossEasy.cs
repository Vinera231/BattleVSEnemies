using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyBossEasy : Enemy
{
    [SerializeField] private int _bullets;
    [SerializeField] private EnemyBossAnimator _animator;

    private Score _score;
    private EnemySpawner _enemySpawner;
    private BulletSpawner _bulletSpawner;
    private LootSpawner _lootSpawner;

    private List<float> _sortedThresholds;
    private HashSet<float> _usedThresholds;

    private readonly Dictionary<float, int> _thresholds = new()
    {
        { 6000, 10 },
        { 5000, 10 },
        { 4000, 5 },
        { 3000, 5 },
        { 2000, 5 },
        { 1000, 5 },
    };

    protected override void Awake()
    {
        base.Awake();
        _enemySpawner = FindFirstObjectByType<EnemySpawner>();
        _bulletSpawner = FindFirstObjectByType<BulletSpawner>();
        _lootSpawner = FindFirstObjectByType<LootSpawner>();
        _score = FindFirstObjectByType<Score>();

        _sortedThresholds = _thresholds.Keys.OrderByDescending(k => k).ToList();
        _usedThresholds = new HashSet<float>();
    }

    private System.Func<Vector3, Enemy> GetSpawnFunctionByIndex(int index)
    {
        return index switch
        {
            0 => _enemySpawner.SpawnEnemy,
            1 => _enemySpawner.SpawnSpeedy,
            2 => _enemySpawner.SpawnHamer,
            _ => throw new System.ArgumentOutOfRangeException(nameof(index), index, "для даного индекса нет зареганих действие"),
        };
    }

    protected override void OnHealthChanged(float value)
    {
        base.OnHealthChanged(value);

        for (int i = 0; i < _sortedThresholds.Count; i++)
        {
            float threshold = _sortedThresholds[i];

            if (_usedThresholds.Contains(threshold) == false && value < threshold)
            {
                int count = _thresholds[threshold];

                if (i == _sortedThresholds.Count - 1)
                {
                    for (int j = 0; j < count; j++)
                    {
                        Enemy enemy = _enemySpawner.SpawnHamer(transform.position);
                        Enemy enemy1 = _enemySpawner.SpawnEnemy(transform.position);
                        Enemy enemy2 = _enemySpawner.SpawnSpeedy(transform.position);
                        Subcrible(enemy);
                        Subcrible(enemy1);
                        Subcrible(enemy2);
                    }
                }
                else
                {
                    System.Func<Vector3, Enemy> spawnFunc = GetSpawnFunctionByIndex(i);
                    SpawnEnemies(count, spawnFunc);
                }

                _usedThresholds.Add(threshold);

                return;
            }
        }

        if (_bulletSpawner.BulletCount < _bullets)
            SpawnEnemies(1, _enemySpawner.SpawnEnemy);
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
        _score.Increaze(enemy.ScoreReward);
    }

    private void Subcrible(Enemy enemy)
    {
        if (enemy == null) return;
        enemy.Died += OnEnemyDied;
    }


    protected override void ProcessDied()
    {
        if (TryGetComponent(out Collider collider))
            Destroy(collider);

        SfxPlayer.Instance.PlayDieBossSound();
        ParticleSpawner.Instance.CreateBlood(transform.position);
        _animator.PlayDied();
        Freeze();
        Invoke(nameof(DestroyBossEasy), 3f);
    }

    private void DestroyBossEasy()
    {
        InvokeDeath();
        Destroy(gameObject);
    }

}
