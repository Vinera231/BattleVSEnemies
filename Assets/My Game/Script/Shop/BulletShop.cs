using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletShop : Shop
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private BulletView _bulletView;
    
    private Dictionary<Type, BulletStats> _bulletStats;

    protected override void Awake()
    {
        _bulletStats = new Dictionary<Type, BulletStats>()
        {
            { typeof(DefaultBullet), new BulletStats(0.5f, 100) },
            { typeof(ExplorelBulett), new BulletStats(1f, 50, 50) },
            { typeof(FrostBullet), new BulletStats(0.2f, 100) },
            { typeof(ExtraBullet), new BulletStats(0.3f, 100) },
            { typeof(PoisonBullet), new BulletStats(0.4f, 100) },
            { typeof(FireBullet), new BulletStats(0.5f, 100) }
        };

        base.Awake();
    }

    protected override bool TryApplyItem()
    {
        Type bulletType = _bulletPrefab.GetType();

        if (_bulletStats.TryGetValue(bulletType, out BulletStats stats))
        {
            _bulletSpawner.ReplacePrefab(_bulletPrefab, stats.Rate, stats.Limit);
            ResetPrice();

            return true;
        }

        throw new Exception("Неучтённый тип пули: " + bulletType);
    }
}
