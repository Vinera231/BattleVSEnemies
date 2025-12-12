using UnityEngine;

public class ParticleShower : MonoBehaviour
{
    [SerializeField] private ExplosionParticle _explosionParticlePrefab;

    private static ExplosionParticle s_explosionParticlePrefab;

    private void Awake()
    {
        s_explosionParticlePrefab = _explosionParticlePrefab;
    }

    public static void PlayExplosion(Vector3 worldPosition)
    {
        ExplosionParticle particle = Instantiate(s_explosionParticlePrefab, worldPosition,Quaternion.identity);
        particle.Play();
    }
}