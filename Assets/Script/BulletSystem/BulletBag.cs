using UnityEngine;

public class BulletBag : MonoBehaviour
{
    [SerializeField] private int _amount = 20;
    [SerializeField] private float _remainingTime = 3f;
    [SerializeField] private float _maximumBullet = 100f;

    private void Update()
    {
        _remainingTime -= Time.deltaTime;

        if (_remainingTime <= 0)
            Destroy(gameObject);

        if (_amount > _maximumBullet)
            gameObject.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            if (player.TryReplenishBullet(_amount))
                Destroy(gameObject);      
    }
}