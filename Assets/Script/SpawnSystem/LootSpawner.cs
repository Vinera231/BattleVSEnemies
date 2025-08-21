using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    [SerializeField] private BulletBag _bulletBagPrefab;
    [SerializeField] private MedKit _kit;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector2 _deviation;

    private MedKit _currentKid;

    public void SpawnBulletBag(Vector3 position)
    {
        BulletBag bulletBag = Instantiate(_bulletBagPrefab, transform);
        bulletBag.transform.position = DeviatePosition(position) + _offset;  
    }

    public void SpawnMedKit()
    {
        if (_currentKid != null)
            return;
        
        _currentKid = Instantiate(_kit, transform);
        _currentKid.transform.position = DeviatePosition(GetRandomPosition()) + _offset;

        _currentKid.OnPickedUp += HandleMedKitPickUp;
    }

    private void HandleMedKitPickUp()
    {
        _currentKid.OnPickedUp -= HandleMedKitPickUp;
        _currentKid = null;
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