using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage = 20f;

    private void Start() =>
        Invoke(nameof(DestroyBullet), 3);

    public void DestroyBullet() =>
        Destroy(gameObject);

    private void OnCollisionEnter(Collision collision) =>
        OnEnter(collision.gameObject);

    private void OnTriggerEnter(Collider other) =>
        OnEnter(other.gameObject);

    private void OnEnter(GameObject other)
    {
        if (other.TryGetComponent(out Enemy enemy) == false)
            return;

        enemy.TakeDamage(_damage);
        Destroy(gameObject);
    }
}