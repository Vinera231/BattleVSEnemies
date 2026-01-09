using System.Collections.Generic;
using UnityEngine;

public class QuietPlace : MonoBehaviour
{
    [SerializeField] private WaveManager _waveManager;

    private readonly List<Enemy> _enemies = new();
    private bool _isActive;

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
            Debug.Log("Enter");
            _isActive = true;
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
            Debug.Log("Exited");
            _isActive = false;
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
