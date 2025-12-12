using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected static Bullet Instance;

    [SerializeField] private float _damage;

    public float Damage => _damage;

    protected virtual  void Start() =>
        Invoke(nameof(DestroyBullet), 3);

    protected virtual void DestroyBullet() =>
        Destroy(gameObject);

    protected virtual void OnCollisionEnter(Collision collision)
    {
        OnEnter(collision.gameObject);

        if (collision.gameObject.TryGetComponent(out BulletIgnore _) == false)
            DestroyBullet();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        OnEnter(other.gameObject);
        
        if (other.gameObject.TryGetComponent(out BulletIgnore _) == false)
            DestroyBullet();
    }

    protected virtual void OnEnter(GameObject other)
    {
        if (other.TryGetComponent(out Enemy enemy))
            enemy.TakeDamage(_damage);
    }


    public virtual void SetDamage(float damage)
    {
        _damage = damage;
    }
}
