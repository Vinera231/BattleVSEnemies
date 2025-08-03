using System;
using UnityEngine;

public class NotShootGun : MonoBehaviour
{
    [SerializeField] private BulletSpawner _spawner;
    [SerializeField] private InputReader _reader;

    public event Action OnShoot;
    
    private void OnEnable()
    {
        _reader.ShotPressed += HandleShoot;
    }

    private void OnDisable()
    {
        _reader.ShotPressed -= HandleShoot;
    }

    public void HandleShoot()
    {
        if (PauseController.Instance != null && PauseController.Instance.IsPause)
            return;
    
        Shoot();
    }

    public void Shoot()
    {
        OnShoot?.Invoke();
    }
}