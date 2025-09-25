using UnityEngine;

public class ExplosionSpawner : MonoBehaviour
{
    public static ExplosionSpawner Instance;

    [SerializeField] private ExplosionParticle _prefab;
    [SerializeField] private Vector3 _offset;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void Create(Vector3 position)
    {
        Instantiate(_prefab, position + _offset, Quaternion.identity);
    }
}