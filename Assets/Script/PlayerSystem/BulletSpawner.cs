using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Rigidbody _freezeRotation;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _velocity = 20f;

    [SerializeField] private bool _isActive = true;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == false)
            return;

        GameObject newBullet = Instantiate(_prefab, transform.position, transform.rotation);
        Rigidbody rigidbody = newBullet.GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * _velocity;
        rigidbody.freezeRotation = true;

        if (!_isActive)   
            return;
      
        _isActive = false;
    }
}