using System;
using System.Collections.Generic;
using UnityEngine;

public class QuietPlace : MonoBehaviour
{
    [SerializeField] private WaveManager _waveManager;

    private readonly List<Enemy> _enemies = new();
    private bool _isActive;
  
    public event Action PlayerEntered;
    public event Action PlayerExited;

    private void OnEnable()
    {
        _waveManager.EnemySpawned += OnEnemySpawned;
        _waveManager.EnemyDied += OnEnemyDied;
    }

    private void OnDisable()
    {
        _waveManager.EnemySpawned -= OnEnemySpawned;
        _waveManager.EnemyDied -= OnEnemyDied;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.ProhibitAttack();
            player.ProhibitJump();

            foreach (Enemy enemy in _enemies)
                enemy.Freeze();

            _isActive = true;
            PlayerEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.AllowAttack();
            player.AllowJump();

            foreach (Enemy enemy in _enemies)
                enemy.ResetFreezen();

            _isActive = false;
            PlayerExited?.Invoke();
        }
    }

    private void OnEnemySpawned(Enemy enemy)
    {
        _enemies.Add(enemy);

        if (_isActive)
            enemy.Freeze();
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _enemies.Remove(enemy);
    }
}
