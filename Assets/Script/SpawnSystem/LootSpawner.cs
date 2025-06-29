using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    [SerializeField] private BulletBag _bulletBagPrefab;
    [SerializeField] private Vector3 _offset;
    
    public void Spawn(Vector3 position)
    {
        BulletBag bulletBag = Instantiate(_bulletBagPrefab, transform);
        bulletBag.transform.position = position + _offset;
    }
}