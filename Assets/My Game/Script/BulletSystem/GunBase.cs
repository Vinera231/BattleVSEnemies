using UnityEngine;

public abstract class GunBase : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    public Transform SpawnPoint => _spawnPoint;
}
