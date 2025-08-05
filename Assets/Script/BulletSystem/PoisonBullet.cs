using UnityEngine;

public class PoisonBullet : MonoBehaviour
{
    [SerializeField] private float _poisonDamage;
    [SerializeField] private float _poisonDuraction;
    [SerializeField] private float _tickInterval = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyPoison(_poisonDamage, _poisonDuraction, _tickInterval);
            Destroy(gameObject);
        }
    }

}