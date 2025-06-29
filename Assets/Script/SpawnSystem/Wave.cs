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
    [SerializeField] private float _timeBeforeSpawn;
    [SerializeField] private string _text;
    [SerializeField] private LootSpawner _lootSpawner;

    private WaitForSeconds _wait;
    private List<Enemy> _enemies = new();

    public event Action Finished;

    public string Text => _text;

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
            Enemy enemy = _spawner.SpawnEnemy(transform.position);
            enemy.Died += OnDied;
            _enemies.Add(enemy);
            _countEnemy--;
        }

        while (_countSpeedy > 0)
        {
            yield return _wait;
            Enemy enemy = _spawner.SpawnSpeedy(transform.position);
            enemy.Died += OnDied;
            _enemies.Add(enemy);
            _countSpeedy--;
        }

        while (_countHamer > 0)
        {
            yield return _wait;
            Enemy enemy = _spawner.SpawnHamer(transform.position);
            enemy.Died += OnDied;
            _enemies.Add(enemy);
            _countHamer--;
        }
    }

    private void OnDied(Enemy enemy)
    {
        _enemies.Remove(enemy);
        _lootSpawner.Spawn(enemy.transform.position);

        if (_enemies.Count == 0)
            Finished?.Invoke();
    }
}