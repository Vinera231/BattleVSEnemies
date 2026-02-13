using UnityEngine;

public class BulletShop : Shop
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private Bullet _bulletPrefab;

    protected override bool TryApplyItem()
    {
        _bulletSpawner.ReplacePrefab(_bulletPrefab);
        ResetPrice();
        return true;
    }
}
