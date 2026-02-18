using UnityEngine;

public class PoisonBullet : Bullet
{
    [SerializeField] private float _poisonDamage;
    [SerializeField] private float _durationInSecond;
    [SerializeField] private float _tickIntervalInSecond = 2f;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if(other.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyPoison(_poisonDamage, _durationInSecond, _tickIntervalInSecond);
            Destroy(gameObject);
        }
    }
}