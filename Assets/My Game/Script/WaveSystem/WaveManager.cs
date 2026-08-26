using System;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Score _score;
    [SerializeField] private Health _health;

    private float _amount = 100f;
    private int _currentWaveIndex = 0;
    private int _waveIndex = 20;
    private bool _specialWaveStarte;

    public event Action<int> WaveStarted;
    public event Action<int> WaveSpecialStarted;
    public event Action AllWavesFinished;
    public event Action<Enemy> EnemySpawned;
    public event Action<Enemy> EnemyDied;

    public bool IsActiveWave => _currentWaveIndex < _waves.Count;

    public int CurrentWaveIndex => _currentWaveIndex;

    public int EnemyKilled { get; private set; }
    public int WavePassed { get; private set; }

    private void Start() =>
        StartWave();

    public string GetWaveName(int index) =>
        _waves[index].Text;

    private void StartWave()
    {
        WavePassed++;
        Wave wave = _waves[_currentWaveIndex];
        wave.StartSpawn();
        wave.Finished += OnWaveFinished;
        wave.EnemyDied += OnEnemyDied;
        wave.Spawned += OnEnemySpawned;
        Vector2 spawnPosition = transform.position;
        WaveStarted?.Invoke(_currentWaveIndex);

        if (_currentWaveIndex == 10)
            AddHealthValue();
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
            StartWave();

        if (_currentWaveIndex >= _waves.Count)
            AllWavesFinished?.Invoke();
    }

    public void StartSpecialWave()
    {
        if (_specialWaveStarte)
            return;

        if (_waveIndex < 0 || _waveIndex >= _waves.Count)
            Debug.LogError($"Special wave index {_waveIndex} is invalid.");

        _specialWaveStarte = true;

        Wave wave = _waves[_waveIndex];
      
        wave.StartSpawn();
        wave.Finished += FinishSpecialWave;
        wave.EnemyDied += OnEnemyDied;
        wave.Spawned += OnEnemySpawned;

        WaveSpecialStarted?.Invoke(_waveIndex); 
    }

    public void FinishSpecialWave()
    {
        Wave wave = _waves[_waveIndex];
      
        wave.StartSpawn();
        wave.Finished -= FinishSpecialWave;
        wave.EnemyDied -= OnEnemyDied;
        wave.Spawned -= OnEnemySpawned;

        _score.Increaze(wave.ScoreReward);

    }
    private void OnEnemySpawned(Enemy enemy) =>
        EnemySpawned?.Invoke(enemy);

    private void OnEnemyDied(Enemy enemy)
    {
        EnemyKilled++;
        EnemyDied?.Invoke(enemy);
        _score.Increaze(enemy.ScoreReward);
    }

    private void AddHealthValue() =>
     _health.RecoverHealth(_amount);
}