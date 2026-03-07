using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Rigidbody _freezeRotation;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _velocity = 20f;
    [SerializeField] private int _bullet;
    [SerializeField] private int _limitbullet;
    [SerializeField] private BulletView _bulletView;
    [SerializeField] private float _fireRate;
    
    private float _damage = 20f;
    private Coroutine _shootCoroutine;
    private WaitForSeconds _waitShoot;
    private bool _canShoot = true;

    public bool IsFull => _bullet >= _limitbullet;

    private void Start()
    {
        _waitShoot = new(_fireRate);
       
    }
    public void ResetBulletDamage()
    {
        _damage = 20f;
    }
    public void ReplacePrefab(Bullet bullet)
    {
        _prefab = bullet;
        _bulletView.UpdateBulletCount(_bullet, _limitbullet);
    }
    public void IncreaseBulletDamage(float amount)
    {
        _damage += amount;
    }

    public void StartShoot(Transform spawnPoint)
    {
        StopShoot();
        _shootCoroutine = StartCoroutine(ShootingRoutine(spawnPoint));
    }

    public void StopShoot()
    {
        if (_shootCoroutine != null)
        {
            StopCoroutine(_shootCoroutine);
            _shootCoroutine = null;
        }
    }

    private IEnumerator ShootingRoutine(Transform spawnPoint)
    {
        while (_canShoot)
        {
            Shoot(spawnPoint);
            yield return _waitShoot;
        }
    }

    private void Shoot(Transform spawnPoint)
    {
        if (_bullet <= 0)
        {
            NotBullet();
            SfxPlayer.Instance.PlayNotBullet();
            return;
        }

        Bullet newBullet = Instantiate(_prefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody rigidbody = newBullet.GetComponent<Rigidbody>();
        rigidbody.linearVelocity = spawnPoint.forward * _velocity;
        rigidbody.freezeRotation = true;

         switch(newBullet)
         {
            case FrostBullet:
                SfxPlayer.Instance.PlayFrostShootSound();
                break;

            case PoisonBullet:
                SfxPlayer.Instance.PlayPoisonSound();
                break;

            case ExtraBullet:
                SfxPlayer.Instance.PlayLaserSound();
                break;

            case ExplorelBulett:
                SfxPlayer.Instance.PlayDetonatorSound();
                break;

            case FireBullet:
                SfxPlayer.Instance.PlayFireShootSound();
                break;

            default:
                 SfxPlayer.Instance.PlayShootSound();
                break;
        }


        newBullet.SetDamage(_damage);

        _bullet--;
        _bulletView.UpdateBulletCount(_bullet, _limitbullet);
    }

    public void AddBullet(int amount)
    {
        _bullet = Mathf.Min(_bullet + amount, _limitbullet);
        _bulletView.UpdateBulletCount(_bullet, _limitbullet);
        SfxPlayer.Instance.PlayReloadBullet();
    }
  

    public void NotBullet()
    {
        _bulletView.UpdateBulletCount(_bullet, _limitbullet);
    }
}