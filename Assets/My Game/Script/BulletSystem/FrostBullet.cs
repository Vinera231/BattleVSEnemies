using UnityEngine;

public class FrostBullet : MonoBehaviour
{
    [SerializeField] private float _slowDown;
    [SerializeField] private float _duraction;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplaySlow(_slowDown,_duraction);
            Destroy(gameObject);
        }
    }
}