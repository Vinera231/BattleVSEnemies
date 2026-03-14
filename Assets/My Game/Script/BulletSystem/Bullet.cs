using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage = 20f;
    [SerializeField] private float _velocity = 20f;
    [SerializeField] private int _bullet;
    public float Damage => _damage;
    public float Velocity => _velocity;
   
    protected virtual void Start() =>
        Invoke(nameof(DestroyBullet), 3);
    
    public abstract void OnShot();

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
 
    public virtual void SetDamage(float damage) => 
        _damage = Mathf.Max(0, damage);   
}