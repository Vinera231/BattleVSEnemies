using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public static ParticleSpawner Instance;

    [SerializeField] private ExplosionParticle _explosionPrefab;
    [SerializeField] private BloodParticle _bloodPrefab;
    [SerializeField] private SpeedParticle _speedParticle;
    [SerializeField] private ParticalFire _particalFire;
    [SerializeField] private Vector3 _explosionOffset;
    [SerializeField] private Vector3 _bloodOffset;
    [SerializeField] private Vector3 _speedOffset;
    [SerializeField] private Vector3 _fireOffset;

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

    public void CreateSpeed(Vector3 position) =>
        Instantiate(_speedParticle, position + _speedOffset, Quaternion.identity);
   
    public void CreateFire(Transform parent, Vector3 position)
    {
        ParticalFire particalFire = Instantiate(_particalFire, parent);
        particalFire.transform.position = position + _fireOffset;
        particalFire.transform.rotation = Quaternion.identity;
    }

}