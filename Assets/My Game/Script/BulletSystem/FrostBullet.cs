using UnityEngine;

public class FrostBullet : Bullet
{
    [SerializeField] private float _slowDown;
    [SerializeField] private float _duraction;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if(other.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplaySlow();
            Destroy(gameObject);
        }
    }
}