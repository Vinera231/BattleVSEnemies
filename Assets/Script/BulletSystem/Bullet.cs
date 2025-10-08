using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage;
    
    private void Start() =>
        Invoke(nameof(DestroyBullet), 3);

    private void DestroyBullet() =>
        Destroy(gameObject);

    private void OnCollisionEnter(Collision collision)
    {
        OnEnter(collision.gameObject);

        if (collision.gameObject.TryGetComponent(out BulletIgnore _) == false)
            DestroyBullet();
    }

    private void OnTriggerEnter(Collider other)
    {
        OnEnter(other.gameObject);
        
        if (other.gameObject.TryGetComponent(out BulletIgnore _) == false)
            DestroyBullet();
    }

    private void OnEnter(GameObject other)
    {
        if (other.TryGetComponent(out Enemy enemy))
            enemy.TakeDamage(_damage);
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }
}