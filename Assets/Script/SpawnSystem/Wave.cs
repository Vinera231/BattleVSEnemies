using System;
using System.Collections;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private float _frequency;
    [SerializeField] private float _countEnemy;
    [SerializeField] private float _countSpeedy;
    [SerializeField] private float _countHamer;
    [SerializeField] private float _timeAfterSpawn;

    private WaitForSeconds _wait;

    public event Action Finished;

    private void Awake()
    {
        _wait = new(_frequency);
    }

    public void StartSpawn()
    {
        StartCoroutine(SpawnOverCount());
    }

    private IEnumerator SpawnOverCount()
    {
        while (_countEnemy > 0)
        {
            yield return _wait;
            _spawner.SpawnEnemy(transform.position);
            _countEnemy--;
        }

        while (_countSpeedy > 0)
        {
            yield return _wait;
            _spawner.SpawnEnemy(transform.position);
            _countSpeedy--;
        }

        while (_countHamer > 0)
        {
            yield return _wait;
            _spawner.SpawnEnemy(transform.position);
            _countHamer--;
        }

        yield return new WaitForSeconds(_timeAfterSpawn);
        Finished?.Invoke();
    }
}