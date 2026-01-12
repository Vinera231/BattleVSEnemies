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
    [SerializeField] private SfxPlayer _player;
    [SerializeField] private float _baseDamage = 10f;
    [SerializeField] private float _fireRate;

    private Coroutine _shootCoroutine;
    private WaitForSeconds _waitShoot;
    private float  _currentDamage;
    private bool _canShoot = true;

    public bool IsFull => _bullet >= _limitbullet;

    private void Start()
    {
        _waitShoot = new(_fireRate);
        _currentDamage = _baseDamage;
    }

    public void ReplacePrefab(Bullet bullet)
    {
        _prefab = bullet;
        _bulletView.UpdateBulletCount(_bullet, _limitbullet);
    }

    public void StartShoot(Transform spawnPoint)
    {
        StopShoot();
        _shootCoroutine = StartCoroutine(ShootingRoutine(spawnPoint));
    }

    public void SetBulletDamage(float value)
    {
        _currentDamage = Mathf.Max(0, value);
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
            _player.PlayNotBullet();
            return;
        }

        Bullet newBullet = Instantiate(_prefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody rigidbody = newBullet.GetComponent<Rigidbody>();
        rigidbody.linearVelocity = spawnPoint.forward * _velocity;
        rigidbody.freezeRotation = true;

       newBullet.SetDamage(_currentDamage);

        _bullet--;
        _bulletView.UpdateBulletCount(_bullet, _limitbullet);
    }

    public void AddBullet(int amount)
    {
        _bullet = Mathf.Min(_bullet + amount, _limitbullet);
        _bulletView.UpdateBulletCount(_bullet, _limitbullet);
        _player.PlayReloadBullet();
    }

    public void IncreaseBulletDamage(float amount)
    {
        _currentDamage += amount;
    }

    public void ResetBulletDamage()
    {
        _currentDamage = _baseDamage;
        Debug.Log($"Bullet damage reset to {_currentDamage}");
    }

    public void NotBullet()
    {
        _bulletView.UpdateBulletCount(_bullet, _limitbullet);
    }
}