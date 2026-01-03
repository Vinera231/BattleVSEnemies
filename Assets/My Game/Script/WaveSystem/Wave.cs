using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner; 
    [SerializeField] private float _frequency;
    [SerializeField] private float _countEnemy;
    [SerializeField] private float _countMonsterEnemy;
    [SerializeField] private float _countSpeedy;
    [SerializeField] private float _countMonsterSpeedy;
    [SerializeField] private float _countHamer;
    [SerializeField] private float _countAngryHamer;
    [SerializeField] private float _countBoss; 
    [SerializeField] private float _countHalmer;
    [SerializeField] private float _countMonsterHalmer;
    [SerializeField] private float _countIron;   
    [SerializeField] private float _countExplorel;
    [SerializeField] private float _countFrost;
    [SerializeField] private float _countRegen;
    [SerializeField] private float _timeBeforeSpawn;
    [SerializeField] private string _text;
    [SerializeField] private LootSpawner _lootSpawner;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private int _scoreReward;

    private WaitForSeconds _wait;
    private readonly List<Enemy> _enemies = new();

    public event Action <Enemy> Spawned;
    public event Action Finished;
    public event Action<Enemy> EnemyDied;

    public int ScoreReward => _scoreReward;

    public string Text => _text;

    private Vector3 RandomSpawnPosition()
    {
        if (_spawnPoints.Count == 0)
            return transform.position;
        else
            return _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position;
    }

    private void Awake() =>
        _wait = new(_frequency);

    public void StartSpawn() =>
        StartCoroutine(SpawnOverCount());

    private IEnumerator SpawnOverCount()
    {
        yield return new WaitForSeconds(_timeBeforeSpawn);

        while (_countEnemy > 0)
        {
            yield return _wait;
            Enemy enemy = _spawner.SpawnEnemy(RandomSpawnPosition());
            enemy.Died += OnDied;
            _enemies.Add(enemy);
            Spawned?.Invoke(enemy);
            _countEnemy--;
        }
        
        while (_countMonsterEnemy > 0)
        {
            yield return _wait;
            Enemy enemy = _spawner.SpawnMonsterEnemy(RandomSpawnPosition());
            enemy.Died += OnDied;
            _enemies.Add(enemy);
            Spawned?.Invoke(enemy);
            _countMonsterEnemy--;
        }

        while (_countSpeedy > 0)
        {
            yield return _wait;
            Enemy enemy = _spawner.SpawnSpeedy(RandomSpawnPosition());
            enemy.Died += OnDied;
            _enemies.Add(enemy);
            Spawned?.Invoke(enemy);
            _countSpeedy--;
        }
       
        while (_countMonsterSpeedy > 0)
        {
            yield return _wait;
            Enemy enemy = _spawner.SpawnMonsterSpeedy(RandomSpawnPosition());
            enemy.Died += OnDied;
            _enemies.Add(enemy);
            Spawned?.Invoke(enemy);
            _countMonsterSpeedy--;
        }

        
        while (_countHamer > 0)
        {
            yield return _wait;
            Enemy enemy = _spawner.SpawnHamer(RandomSpawnPosition());
            enemy.Died += OnDied;
            _enemies.Add(enemy);
            Spawned?.Invoke(enemy);
            _countHamer--;
        }
       
        while (_countAngryHamer > 0)
        {
            yield return _wait;
            Enemy enemy = _spawner.SpawnAngryHamer(RandomSpawnPosition());
            enemy.Died += OnDied;
            _enemies.Add(enemy);
            Spawned?.Invoke(enemy);
            _countAngryHamer--;
        }
      
        while(_countBoss > 0)
        {
            yield return _wait;
            Enemy enemy = _spawner.SpawnBoss(RandomSpawnPosition());
            enemy.Died += OnDied;
            _enemies.Add(enemy);
            Spawned?.Invoke(enemy);
            _countBoss--;
        }

        while (_countHalmer > 0)
        {
            yield return _wait;
            Enemy enemy = _spawner.SpawnHalmer(RandomSpawnPosition());
            enemy.Died += OnDied;
            _enemies.Add(enemy);
            Spawned?.Invoke(enemy);
            _countHalmer--;
        }
       
        while (_countMonsterHalmer > 0)
        {
            yield return _wait;
            Enemy enemy = _spawner.SpawnMonsterHalmer(RandomSpawnPosition());
            enemy.Died += OnDied;
            _enemies.Add(enemy);
            Spawned?.Invoke(enemy);
            _countMonsterHalmer--;
        }

        while (_countIron > 0)
        {
            yield return _wait;
            Enemy enemy = _spawner.SpawnIron(RandomSpawnPosition());
            enemy.Died += OnDied;
            _enemies.Add(enemy);
            Spawned?.Invoke(enemy);
            _countIron--;
        }
        
        while (_countExplorel > 0)
        {
            yield return _wait;
            Enemy enemy = _spawner.SpawnExplorel(RandomSpawnPosition());
            enemy.Died += OnDied;
            _enemies.Add(enemy);
            Spawned?.Invoke(enemy);
            _countExplorel--;
        }

        while (_countFrost > 0)
        {
            yield return _wait;
            Enemy enemy = _spawner.SpawnFrost(RandomSpawnPosition());
            enemy.Died += OnDied;
            _enemies.Add(enemy);
            Spawned?.Invoke(enemy);
            _countFrost--;
        }
       
        while (_countRegen > 0)
        {
            yield return _wait;
            Enemy enemy = _spawner.SpawnRegen(RandomSpawnPosition());
            enemy.Died += OnDied;
            _enemies.Add(enemy);
            Spawned?.Invoke(enemy);
            _countRegen--;
        }
    }

    private void OnDied(Enemy enemy)
    {
        _enemies.Remove(enemy);
        _lootSpawner.SpawnBulletBag(enemy.transform.position);
        EnemyDied?.Invoke(enemy);

        if (_enemies.Count == 0)
            Finished?.Invoke();
    }
}