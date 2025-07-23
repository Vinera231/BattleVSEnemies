using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner; 
    [SerializeField] private float _frequency;
    [SerializeField] private float _countEnemy;
    [SerializeField] private float _countSpeedy;
    [SerializeField] private float _countHamer;
    [SerializeField] private float _countBoss;
    [SerializeField] private float _timeBeforeSpawn;
    [SerializeField] private string _text;
    [SerializeField] private LootSpawner _lootSpawner;
    [SerializeField] private List<Transform> _spawnPoints;

    private WaitForSeconds _wait;
    private readonly List<Enemy> _enemies = new();

    public event Action Finished;

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
            _countEnemy--;
        }

        while (_countSpeedy > 0)
        {
            yield return _wait;
            Enemy enemy = _spawner.SpawnSpeedy(RandomSpawnPosition());
            enemy.Died += OnDied;
            _enemies.Add(enemy);
            _countSpeedy--;
        }

        while (_countHamer > 0)
        {
            yield return _wait;
            Enemy enemy = _spawner.SpawnHamer(RandomSpawnPosition());
            enemy.Died += OnDied;
            _enemies.Add(enemy);
            _countHamer--;
        }
    
        while(_countBoss > 0)
        {
            yield return _wait;
            Enemy enemy = _spawner.SpawnBoss(RandomSpawnPosition());
            enemy.Died += OnDied;
            _enemies.Add(enemy);
            _countBoss--;
        }

    }

    private void OnDied(Enemy enemy)
    {
        _enemies.Remove(enemy);
        _lootSpawner.SpawnBulletBag(enemy.transform.position);

        if (_enemies.Count == 0)
            Finished?.Invoke();
    }
}