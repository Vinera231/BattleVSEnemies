using UnityEngine;
using UnityEngine.UIElements;

public class ParticleSpawner : MonoBehaviour
{
    public static ParticleSpawner Instance;

    [SerializeField] private ExplosionParticle _explosionPrefab;
    [SerializeField] private BloodParticle _bloodPrefab;
    [SerializeField] private Vector3 _explosionOffset;
    [SerializeField] private Vector3 _bloodOffset;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void CreateExplosion(Vector3 position) =>
        Instantiate(_explosionPrefab, position + _explosionOffset, Quaternion.identity); 

    public void CreateBlood(Vector3 position) =>
        Instantiate(_bloodPrefab, position + _bloodOffset, Quaternion.identity);    
}