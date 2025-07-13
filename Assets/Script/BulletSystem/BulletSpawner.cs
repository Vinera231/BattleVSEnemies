using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Rigidbody _freezeRotation;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _velocity = 20f;
    [SerializeField] private bool _isActive = true;
    [SerializeField] private int _bullet;
    [SerializeField] private int _limitbullet;
    [SerializeField] private BulletView _bulletView;
    [SerializeField] private SfxPlayer _player;


    private void OnEnable()
    {
        _inputReader.ShotPressed += OnShotPressed;  
    }
    private void OnDisable()
    {
        _inputReader.ShotPressed -= OnShotPressed;
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

        GameObject newBullet = Instantiate(_prefab, transform.position, transform.rotation);
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
        Debug.Log("����� �������� �������");
        _player.PlayReloadBullet();
    }

    public void NotBullet()
    {
        Debug.Log("��� ��������");

        _bulletView.UpdateBulletCount(_bullet,_limitbullet);
    }
} 