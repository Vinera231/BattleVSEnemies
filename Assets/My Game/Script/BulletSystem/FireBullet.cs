using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] private float _fireDamage;
    [SerializeField] private float _durationInSecond;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplayFire(_fireDamage,_durationInSecond);
            Destroy(gameObject);
        }
    }
}