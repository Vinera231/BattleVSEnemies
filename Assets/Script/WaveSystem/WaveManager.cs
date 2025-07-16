using System;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private WaveManagerView _view;
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private LootSpawner _spawner;

    private float _waveStartTime;
    private bool _isActiveWave;
    private int _currentWaveIndex = 0;

    public event Action AllWavesFinished;

    private void Start() =>
        StartWave(_currentWaveIndex);

    private void Update()
    {
        if (_isActiveWave == false)
            return;

        float elapsed = Time.time - _waveStartTime;
        _view.SetTime(elapsed);
    }

    private void StartWave(int index)
    {
        _currentWaveIndex = index;
        _waveStartTime = Time.time;
        _isActiveWave = true;
        _waves[index].StartSpawn();
        _waves[index].Finished += OnWaveFinished;
        _view.SetName(_waves[index].Text);
     
        Vector2 spawnPosition = transform.position;
        _spawner.SpawnBulletBag();
        _spawner.SpawnMedKit();
    }

    private void OnWaveFinished()
    {
        _waves[_currentWaveIndex].Finished -= OnWaveFinished;
        ++_currentWaveIndex;

        if (_currentWaveIndex < _waves.Count)
            StartWave(_currentWaveIndex);
        
        if(_currentWaveIndex > _waves.Count)
            ProcessFinished();
    }

    private void ProcessFinished()
    {
        _isActiveWave = false;
        AllWavesFinished?.Invoke();
    }
}