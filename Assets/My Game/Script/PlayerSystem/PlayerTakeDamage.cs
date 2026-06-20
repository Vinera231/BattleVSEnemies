using System;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    [SerializeField] private Health _health;
   
    public event Action PlayerDied;

    private void OnEnable()
    {
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    public void TakeDamage(float value) =>
   _health.TakeDamage(value);

    public bool TryTakeHealth(int life)
    {
        if (_health.IsFull == false)
        {
            _health.RecoverHealth(life);
            SfxPlayer.Instance.PlayRecoverPlayer();
            return true;
        }
        return false;
    }

    public void OnDied()
    {
        PlayerDied?.Invoke();
        SfxPlayer.Instance.PlayDiePlayerSound();
    }
}