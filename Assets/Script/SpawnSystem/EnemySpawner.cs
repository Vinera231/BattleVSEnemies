using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Enemy _speedyPrefab;
    [SerializeField] private Enemy _hamerPrefab;
    [SerializeField] private Vector2 _deviation;

    public void SpawnEnemy(Vector3 position) =>
       Spawn(position, _enemyPrefab);
  
    public void SpawnSpeedy(Vector3 position)=>
        Spawn(position, _speedyPrefab);

    public void SpawnHamer(Vector3 position) =>
        Spawn(position, _hamerPrefab);
    
    private void Spawn(Vector3 position, Enemy prefab) =>
        Instantiate(prefab, DeviatePosition(position), Quaternion.identity);

    private Vector3 DeviatePosition(Vector3 position)
    {
        Vector3 offset = new(
           Random.Range(-_deviation.x, _deviation.x),
           0,
           Random.Range(-_deviation.y, _deviation.y));

        return offset + position;
    }
}