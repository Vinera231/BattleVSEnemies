using System;
using UnityEngine;

public class DistanceDetector : MonoBehaviour
{
    public event Action<Transform> Detected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerControler player))
            Detected?.Invoke(player.transform); 
    }
}