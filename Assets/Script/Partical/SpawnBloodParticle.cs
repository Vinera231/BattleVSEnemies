using UnityEngine;

public class SpawnBloodParticle : MonoBehaviour
{
    public static SpawnBloodParticle Instance { get; private set; }

    [SerializeField] private BloodParticle _prefab;
    [SerializeField] private Vector3 _offset;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void CreateBlood(Vector3 position)
    {
        Instantiate(_prefab, position + _offset, Quaternion.identity);
    }
}