using UnityEngine;

public class BulletBag : MonoBehaviour
{
    [SerializeField] private int _amount = 20;
    [SerializeField] private float _remainingTime = 3f;

    private void Update()
    {
        _remainingTime -= Time.deltaTime;

        if ( _remainingTime <= 0) 
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.ReplenishBullet(_amount);
            Destroy(gameObject);     
        }    
    }
}