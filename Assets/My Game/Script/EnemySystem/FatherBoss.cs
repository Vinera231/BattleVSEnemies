using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FatherBoss : Enemy
{
    [SerializeField] private int _bullets;
    [SerializeField] private EnemyBossAnimator _animator;
    [SerializeField] private DrinkPotionAnimation _potionAnimation;
    [SerializeField] private RadioAnimation _radioAnimation;

    private WaveManager _wave;
    private Score _score;
    private EnemySpawner _enemySpawner;
    private BulletSpawner _bulletSpawner;
    private LootSpawner _lootSpawner;

    private List<float> _sortedThresholds;
    private HashSet<float> _usedThresholds;

    public int FatherBossKilled;

    private readonly Dictionary<float, int> _thresholds = new()
    {
        { 18000, 25 },
        { 16000, 20 },
        { 15000, 25 },
        { 14000, 20 },
        { 13000, 15 },
        { 12000, 10 },
        { 10000, 20 },
        { 8000, 25 },
        { 6000, 30 },
        { 4000, 5 },
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
            1 => _enemySpawner.SpawnMonsterEnemy,
            2 => _enemySpawner.SpawnSpeedy,
            3 => _enemySpawner.SpawnMonsterSpeedy,
            4 => _enemySpawner.SpawnHamer,
            5 => _enemySpawner.SpawnAngryHamer,
            6 => _enemySpawner.SpawnHalmer,
            7 => _enemySpawner.SpawnMonsterHalmer,
            8 => _enemySpawner.SpawnHalmer,
            9 => _enemySpawner.SpawnExplorel,
            10 => _enemySpawner.SpawnIron,
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
                        Enemy enemy = _enemySpawner.SpawnAngryHamer(transform.position);
                        Enemy enemy1 = _enemySpawner.SpawnEnemy(transform.position);
                        Enemy enemy2 = _enemySpawner.SpawnSpeedy(transform.position);
                        Enemy enemy3 = _enemySpawner.SpawnMonsterSpeedy(transform.position);
                        Enemy enemy4 = _enemySpawner.SpawnMonsterEnemy(transform.position);
                        Enemy enemy5 = _enemySpawner.SpawnHalmer(transform.position);
                        Enemy enemy6 = _enemySpawner.SpawnMonsterHalmer(transform.position);
                        Enemy enemy7 = _enemySpawner.SpawnExplorel(transform.position);
                        Enemy enemy8 = _enemySpawner.SpawnIron(transform.position);
                        Subcrible(enemy);
                        Subcrible(enemy1);
                        Subcrible(enemy2);
                        Subcrible(enemy3);
                        Subcrible(enemy4);
                        Subcrible(enemy5);
                        Subcrible(enemy6);
                        Subcrible(enemy7);
                        Subcrible(enemy8);
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

        if (value <= 4000)
        {
            _potionAnimation.OnDrinkHealthAnimation();
            
            if(value == 9000)
                Destroy(_potionAnimation);
        }

        if (value <= 8000)
        {
            _radioAnimation.OnAnimationRadio();
            _wave.StartSpecialWave();
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
        _score.Increaze(enemy.ScoreReward);
    }

    private void Subcrible(Enemy enemy)
    {
        if (enemy == null) return;
        enemy.Died += OnEnemyDied;
    }

    protected override void ProcessDied()
    {
        FatherBossKilled++;
        if (TryGetComponent(out Collider collider))
            Destroy(collider);

        SfxPlayer.Instance.PlayDieBossSound();
        ParticleSpawner.Instance.CreateBlood(transform.position);
        _animator.PlayDied();
        Freeze();
        Invoke(nameof(DestroyBoss), 3f);
    }

    private void DestroyBoss()
    {
        InvokeDeath();
        Destroy(gameObject);
    }
}