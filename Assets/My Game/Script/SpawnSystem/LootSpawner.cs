using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    [SerializeField] private BulletBag _bulletBagPrefab;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector2 _deviation;

    public void SpawnBulletBag(Vector3 position)
    {
        BulletBag bulletBag = Instantiate(_bulletBagPrefab, transform);
        bulletBag.transform.position = DeviatePosition(position) + _offset;  
    }

    private Vector3 DeviatePosition(Vector3 position)
    {
        Vector3 offset = new(
           Random.Range(-_deviation.x, _deviation.x),
           0,
           Random.Range(-_deviation.y, _deviation.y));

        return offset + position;
    }
}