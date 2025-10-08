using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Rigidbody _freezeRotation;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _velocity = 20f;
    [SerializeField] private int _bullet;
    [SerializeField] private int _limitbullet;
    [SerializeField] private BulletView _bulletView;
    [SerializeField] private SfxPlayer _player;
    [SerializeField] private TutorialPanel _tutorial;
    [SerializeField] private float _baseDamage = 10f;

    private float _currentDamage;
    private bool _canShoot = true;

    public bool IsFull => _bullet >= _limitbullet;

    private void Start()
    {
        _currentDamage = _baseDamage;

         _tutorial = FindFirstObjectByType<TutorialPanel>();
        if (_tutorial != null)
        {
            _tutorial.Changed += SetShootingActive;
            _canShoot = !_tutorial.IsActive;
        }
    }

    private void OnDestroy()
    {
        if (_tutorial != null)
            _tutorial.Changed -= SetShootingActive;
    }

   private void OnEnable()
    {
        _inputReader.ShotPressed += OnShotPressed;
    }

    private void OnDisable() =>
        _inputReader.ShotPressed -= OnShotPressed;

    private void SetShootingActive(bool isActive)
    {
        Debug.Log("SetShootingActive" + isActive);
        _canShoot = isActive;
    }

    public void ReplacePrefab(Bullet bullet)
    {
        _prefab = bullet;
        Debug.Log("ReplacePrefab");
        _bulletView.UpdateBulletCount(_bullet, _limitbullet);
    }

    private void OnShotPressed()
    {
        if (!_canShoot)
        {
            Debug.Log("stop Shoot");
            return;     
        }

        if (_bullet <= 0)
        {
            NotBullet();
            _bulletView.UpdateBulletCount(_bullet, _limitbullet);
            _player.PlayNotBullet();
            return;

        }

        Bullet newBullet = Instantiate(_prefab, transform.position, transform.rotation);
        Rigidbody rigidbody = newBullet.GetComponent<Rigidbody>();
        rigidbody.linearVelocity = transform.forward * _velocity;
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