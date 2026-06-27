using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private GunBase _gun;
    [SerializeField] private Score _score;

    private int _point = 5;
    private int _allowedShootingCounter = 1;

    public void IncreaseBulletDamage(int amount)
    {
        _bulletSpawner?.IncreaseBulletDamage(amount);
        ResetBulletDamageToDefaul();
    }

    public void ResetBulletDamageToDefaul() =>
        _bulletSpawner?.ResetBulletDamage();

    public void ShotPressed()
    {
        if (PauseSwitcher.Instance.IsPaused)
            return;

        if (_allowedShootingCounter > 0)
            _bulletSpawner.StartShoot(_gun.SpawnPoint);
    }

    public void ShotUnpressed() =>
        _bulletSpawner.StopShoot();

    public void SetGun(GunBase gun)
    {
        _gun.gameObject.SetActive(false);
        _gun = gun;
        _gun.gameObject.SetActive(true);
    }

    public void AllowAttack() =>
        _allowedShootingCounter++;

    public void ProhibitAttack()
    {
        _bulletSpawner.StopShoot();
        _allowedShootingCounter--;
    }
  
    public bool TryReplenishBullet(int amount)
    {
        if (_bulletSpawner.IsFull == false)
        {
            _bulletSpawner.AddBullet(amount);
            return true;
        }
        else
        {
            _score.Increaze(_point);
            return true;
        }
    }
}