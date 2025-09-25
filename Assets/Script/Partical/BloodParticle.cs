using UnityEngine;

public class BloodParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;

    private void OnEnable()
    {
        _particle.Play();
    }

    private void Update()
    {
        if (_particle.isPlaying == false)
            Destroy(gameObject);
    }
}