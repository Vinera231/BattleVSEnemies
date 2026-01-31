using System;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Score _score;

    private int _currentWaveIndex = 0;

    public event Action<int> WaveStarted;
    public event Action AllWavesFinished;
    public event Action<Enemy> EnemySpawned;
    public event Action<Enemy> EnemyDied;

    public bool IsActiveWave => _currentWaveIndex < _waves.Count;

    public int CurrentWaveIndex => _currentWaveIndex;

    private void Start() =>
        StartWave(_currentWaveIndex);

    public string GetWaveName(int index) =>  
        _waves[index].Text;
  
    public void DeleteBoss() =>   
       _waves.Remove(_waves[9]);
  
    private void StartWave(int index)
    {
        _currentWaveIndex = index;
        Wave wave = _waves[index];
        wave.StartSpawn();
        wave.Finished += OnWaveFinished;
        wave.EnemyDied += OnEnemyDied;
        wave.Spawned += OnEnemySpawned;
        Vector2 spawnPosition = transform.position;
        Debug.Log($"{_currentWaveIndex}");
        WaveStarted?.Invoke(_currentWaveIndex);
    }
    
    private void OnWaveFinished()
    {
        Wave wave = _waves[_currentWaveIndex];
        wave.Finished -= OnWaveFinished;
        wave.EnemyDied -= OnEnemyDied;
        wave.Spawned -= OnEnemySpawned;

        _score.Increaze(wave.ScoreReward);
        ++_currentWaveIndex;

        if (_currentWaveIndex < _waves.Count)
            StartWave(_currentWaveIndex);

        if (_currentWaveIndex > _waves.Count)
            AllWavesFinished?.Invoke();
    }
  
    private void OnEnemySpawned(Enemy enemy)
    {
        ParticleSpawner.Instance.CreateSpawnerPartical(enemy.transform, enemy.transform.position);
        EnemySpawned?.Invoke(enemy);
    }
  
    private void OnEnemyDied(Enemy enemy)
    {
        EnemyDied?.Invoke(enemy);
        _score.Increaze(enemy.ScoreReward);
    }
}