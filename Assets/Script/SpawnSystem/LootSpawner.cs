using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LootSpawner : MonoBehaviour
{
    [SerializeField] private BulletBag _bulletBagPrefab;
    [SerializeField] private MedKit _kit;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector2 _deviation;

    public void Spawn(Vector3 position)
    {
        BulletBag bulletBag = Instantiate(_bulletBagPrefab, transform);
        bulletBag.transform.position = DeviatePosition(position) + _offset;  
   
        MedKit kit = Instantiate(_kit, transform);
        kit.transform.position = DeviatePosition(position) + _offset;
    }

    public void Spawn()
    {
        BulletBag bulletBag = Instantiate(_bulletBagPrefab, transform);
        bulletBag.transform.position = DeviatePosition(GetRandomPosition()) + _offset;

        MedKit kit = Instantiate(_kit, transform);
        kit.transform.position = DeviatePosition(GetRandomPosition()) + _offset;
    }

    private Vector3 DeviatePosition(Vector3 position)
    {
        Vector3 offset = new(
           Random.Range(-_deviation.x, _deviation.x),
           0,
           Random.Range(-_deviation.y, _deviation.y));

        return offset + position;
    }

    private Vector3 GetRandomPosition()
    {
        if (_spawnPoints.Count == 0)
            return transform.position;
        else
            return _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
    }
}