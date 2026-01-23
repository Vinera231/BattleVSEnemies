using UnityEngine;

public class SpawnerPartical : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;

    public void OnEnable()
    {
        _particle.Play();
    }

    public void Update()
    {
        if(_particle.isPlaying == false) 
            Destroy(gameObject);
    }
}
