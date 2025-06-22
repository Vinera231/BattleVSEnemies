using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _CustomGameObject;
  
    private void Start()
    {
        Invoke(nameof(DestroyBullet), 3);
        Debug.Log("Hit Something");
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 position = collision.contacts[0].point;
        Quaternion rotation = Quaternion.LookRotation(collision.contacts[0].normal);
        
        
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(20f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        Vector3 position = other.transform.position;
        Quaternion rotation = Quaternion.identity;


        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(20f);
            Destroy(gameObject);
        }
    }
}