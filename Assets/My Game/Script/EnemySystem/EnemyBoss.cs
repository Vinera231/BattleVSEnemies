using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyBoss : Enemy
{
    [SerializeField] private int _bullets;
    [SerializeField] private EnemyBossAnimator _animator;
    [SerializeField] private Score _score;
   
    private float _currentBulletCount;
    private EnemySpawner _spawner;
    private LootSpawner _lootSpawner;

    private List<float> _sortedThresholds;
    private HashSet<float> _usedThresholds;

    private readonly Dictionary<float, int> _thresholds = new()
    {
        { 7000, 10 },
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
        _spawner = FindFirstObjectByType<EnemySpawner>();
        _lootSpawner = FindFirstObjectByType<LootSpawner>();

        _sortedThresholds = _thresholds.Keys.OrderByDescending(k => k).ToList();
        _usedThresholds = new HashSet<float>();
    }

    private System.Func<Vector3, Enemy> GetSpawnFunctionByIndex(int index)
    {
        return index switch
        {
            0 => _spawner.SpawnEnemy,
            1 => _spawner.SpawnMonsterEnemy,    
            2 => _spawner.SpawnSpeedy,          
            3 => _spawner.SpawnMonsterSpeedy,  
            4 => _spawner.SpawnMonsterSpeedy,   
            5 => _spawner.SpawnHamer,          
            _ => _spawner.SpawnEnemy            // запасной вариант
        };
    }


    protected override void OnHealthChanged(float value)
    {
        base.OnHealthChanged(value);

        for (int i = 0; i < _sortedThresholds.Count; i++)
        {
            float threshold = _sortedThresholds[i];
            if (!_usedThresholds.Contains(threshold) && value < threshold)
            {
                int count = _thresholds[threshold];

                if (i == _sortedThresholds.Count - 1)
                {
                    for (int j = 0; j < count; j++) // count = 5
                    {
                        Enemy enemy = _spawner.SpawnAngryHamer(transform.position);
                        Enemy enemy1 = _spawner.SpawnEnemy(transform.position);
                        Enemy enemy2 = _spawner.SpawnSpeedy(transform.position);
                        Subcrible(enemy);
                        Subcrible(enemy1);
                        Subcrible(enemy2);
                    }
                }
                else
                {
                    var spawnFunc = GetSpawnFunctionByIndex(i);
                    SpawnEnemies(count, spawnFunc);
                }

                _usedThresholds.Add(threshold);
                return;
            }
        }

        if (_currentBulletCount < _bullets)
            SpawnEnemies(1, _spawner.SpawnEnemy);
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
        enemy.Died += OnEnemyDied;
    }
    
    public void UpdateBulletCount(float _current)
    {
        _currentBulletCount = _current;
    }

    protected override void ProcessDied()
    {
        if(TryGetComponent(out Collider collider))
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