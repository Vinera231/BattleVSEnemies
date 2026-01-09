using System;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private WaveManagerView _view;
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Score _score;

    private float _waveStartTime;
    private bool _isActiveWave;
    private int _currentWaveIndex = 0;

    public event Action AllWavesFinished;
    public event Action<Enemy> EnemySpawned;
    public event Action<Enemy> EnemyDied;

    private void Start() =>
        StartWave(_currentWaveIndex);

    private void Update()
    {
        if (_isActiveWave == false)
            return;

        float elapsed = Time.time - _waveStartTime;
        _view.SetTime(elapsed);
    }

    public void StartWave(int index)
    {
        _currentWaveIndex = index;
        _waveStartTime = Time.time;
        _isActiveWave = true;
        _waves[index].StartSpawn();
        _waves[index].Finished += OnWaveFinished;
        _waves[index].EnemyDied += OnEnemyDied;
        _waves[index].Spawned += OnEnemySpawned;
        _view.SetName(_waves[index].Text);
        Vector2 spawnPosition = transform.position;
    }

    private void OnWaveFinished()
    {
        Wave wave = _waves[_currentWaveIndex];
        wave.Finished -= OnWaveFinished;
        wave.EnemyDied -= OnEnemyDied;
        wave.Spawned -= OnEnemySpawned;

        _score.Increaze(wave.ScoreReward);
        Debug.Log($"Increaze дали очки");

        ++_currentWaveIndex;

        if (_currentWaveIndex < _waves.Count)
            StartWave(_currentWaveIndex);

        if (_currentWaveIndex > _waves.Count)
            ProcessFinished();
    }

    private void ProcessFinished()
    {
        _isActiveWave = false;
        AllWavesFinished?.Invoke();
    }
  
    private void OnEnemySpawned(Enemy enemy)
    {
        EnemySpawned?.Invoke(enemy);
    }
  
    private void OnEnemyDied(Enemy enemy)
    {
        EnemyDied?.Invoke(enemy);
        _score.Increaze(enemy.ScoreReward);
    }
}