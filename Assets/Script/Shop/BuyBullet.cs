using UnityEngine;

public class BuyBullet : Shop
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private Bullet _bulletPrefab;

    protected override bool GiveItem()
    {
      _bulletSpawner.ReplacePrefab(_bulletPrefab);
        return true;
    }
}