using System;
using UnityEngine;

public class DistanceDetector : MonoBehaviour
{
    public event Action<Player> Detected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            Detected?.Invoke(player); 
    }
}