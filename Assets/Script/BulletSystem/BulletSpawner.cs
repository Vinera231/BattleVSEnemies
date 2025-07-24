using UnityEditor;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Rigidbody _freezeRotation;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _velocity = 20f;
    [SerializeField] private bool _isActive = true;
    [SerializeField] private int _bullet;
    [SerializeField] private int _limitbullet;
    [SerializeField] private BulletView _bulletView;
    [SerializeField] private SfxPlayer _player;

    public bool IsFull => _bullet >= _limitbullet;

    private void OnEnable() =>
        _inputReader.ShotPressed += OnShotPressed;  
    
    private void OnDisable() =>  
        _inputReader.ShotPressed -= OnShotPressed;  

    public void ReplacePrefab(Bullet bullet)
    {
        _prefab = bullet;
        Debug.Log("ReplacePrefab");
    }

    private void OnShotPressed()
    {
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

        _bullet--;
        _bulletView.UpdateBulletCount(_bullet, _limitbullet);
       

        if (_isActive == false)
            return;

        _isActive = false;
    }
    
    public void AddBullet(int amount)
    {
        _bullet = Mathf.Min(_bullet + amount, _limitbullet);
        _bulletView.UpdateBulletCount(_bullet, _limitbullet);
        Debug.Log("патроны");
        _player.PlayReloadBullet();     
    }

    public void MaxBullet()
    {
        Debug.Log("Уже есть патроны");

       _bulletView.UpdateBulletCount(_bullet, _limitbullet);
    }

    public void NotBullet()
    {
        Debug.Log("нет патронав");

        _bulletView.UpdateBulletCount(_bullet,_limitbullet);    
    }
} 