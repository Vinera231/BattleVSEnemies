using System;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private int _healthAmount;

    public event Action  OnPickedUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))     
            if (player.TryTakeHealth(_healthAmount))
            {
                Destroy(gameObject);
                OnPickedUp?.Invoke();
            }
    }
}