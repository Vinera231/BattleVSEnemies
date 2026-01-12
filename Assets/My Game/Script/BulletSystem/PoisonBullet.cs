using UnityEngine;

public class PoisonBullet : MonoBehaviour
{
    [SerializeField] private float _poisonDamage;
    [SerializeField] private float _durationInSecond;
    [SerializeField] private float _tickIntervalInSecond = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyPoison(_poisonDamage, _durationInSecond, _tickIntervalInSecond);
            Destroy(gameObject);
        }
    }

}