using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Rigidbody _freezeRotation;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _velocity = 20f;
    [SerializeField] private bool _isActive = true;

    private void OnEnable() =>
        _inputReader.ShotPressed += OnShotPressed;

    private void OnDisable() =>
        _inputReader.ShotPressed -= OnShotPressed;

    private void OnShotPressed()
    {
        GameObject newBullet = Instantiate(_prefab, transform.position, transform.rotation);
        Rigidbody rigidbody = newBullet.GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * _velocity;
        rigidbody.freezeRotation = true;

        if (_isActive == false)
            return;

        _isActive = false;
    }
}