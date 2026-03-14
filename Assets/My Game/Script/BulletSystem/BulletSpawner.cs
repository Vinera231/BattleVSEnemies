using System;
using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Rigidbody _freezeRotation;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private int _bullet;
    [SerializeField] private int _limitbullet;
    [SerializeField] private BulletView _bulletView;
    [SerializeField] private float _defaultRate = 0.2f;

    private float _currentDefaultDamage;
    private Coroutine _shootCoroutine;
    private WaitForSeconds _waitShoot;
    private bool _canShoot = true;

    public event Action BulletChanged;

    public int BulletCount => _bullet;

    public bool IsFull => _bullet >= _limitbullet;

    private void Start()
    {
        SetRate(_defaultRate);
        UpdateCurrentDamage();
    }

    private void SetRate(float rate) =>
        _waitShoot = new(rate);

    private void UpdateCurrentDamage() =>
        _currentDefaultDamage = _prefab.Damage;

    public void ResetBulletDamage() =>
        _prefab.SetDamage(_currentDefaultDamage);

    public void ReplacePrefab(Bullet bullet, float rate, int limit)
    {
        _prefab = bullet;
        _limitbullet = limit;
        SetRate(rate);

        UpdateCurrentDamage();

        if (_bullet > _limitbullet)
        {
            _bullet = _limitbullet;
            BulletChanged?.Invoke();
        }
    }

    public void IncreaseBulletDamage(float amount) =>
        _prefab.SetDamage(_prefab.Damage + amount);

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
            SfxPlayer.Instance.PlayNotBullet();
            return;
        }

        Bullet newBullet = Instantiate(_prefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody rigidbody = newBullet.GetComponent<Rigidbody>();
        rigidbody.linearVelocity = spawnPoint.forward * newBullet.Velocity;
        rigidbody.freezeRotation = true;
        newBullet.OnShot();
        _bullet--;
        BulletChanged?.Invoke();
    }

    public void AddBullet(int amount)
    {
        _bullet = Mathf.Min(_bullet + amount, _limitbullet);
        BulletChanged?.Invoke();
        SfxPlayer.Instance.PlayReloadBullet();
    }
}