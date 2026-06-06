using UnityEngine;

public class SawPartical : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;

    private void OnEnable() =>
   _particle.Play();

}