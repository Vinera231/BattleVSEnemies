using UnityEngine;

public class FireBullet : Bullet
{
    [SerializeField] private float _fireDamage;
    [SerializeField] private float _durationInSecond;

    public override void OnShot() =>
        SfxPlayer.Instance.PlayFireShootSound();

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyFire(_fireDamage, _durationInSecond);
            Destroy(gameObject);
        }
    }
}