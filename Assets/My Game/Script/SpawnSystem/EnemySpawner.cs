using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Enemy _monsterEnemyPrefab;
    [SerializeField] private Enemy _speedyPrefab;
    [SerializeField] private Enemy _monsterSpeedyPrefab;
    [SerializeField] private Enemy _hamerPrefab;
    [SerializeField] private Enemy _angryHamerPrefab;
    [SerializeField] private Enemy _bossPrefab;
    [SerializeField] private Enemy _halmerEnemy;
    [SerializeField] private Enemy _monsterHalmerEnemy;
    [SerializeField] private Enemy _ironEnemy;
    [SerializeField] private Enemy _explorelEnemy;
    [SerializeField] private Enemy _frostEnemy;
    [SerializeField] private Enemy _regenEnemy;
    [SerializeField] private Vector2 _deviation;

    public Enemy SpawnBoss(Vector3 position) =>
        Spawn(position, _bossPrefab);

    public Enemy SpawnEnemy(Vector3 position) =>
         Spawn(position, _enemyPrefab);
  
    public Enemy SpawnMonsterEnemy(Vector3 position) =>
        Spawn(position, _monsterEnemyPrefab);

    public Enemy SpawnSpeedy(Vector3 position) =>
        Spawn(position, _speedyPrefab);
   
    public Enemy SpawnMonsterSpeedy(Vector3 position) =>
        Spawn(position, _monsterSpeedyPrefab);

    public Enemy SpawnHamer(Vector3 position) =>
        Spawn(position, _hamerPrefab);
   
    public Enemy SpawnAngryHamer(Vector3 position) =>
        Spawn(position, _angryHamerPrefab);
   
    public Enemy SpawnHalmer(Vector3 position) =>
         Spawn(position, _halmerEnemy);
   
    public Enemy SpawnMonsterHalmer(Vector3 position) =>
         Spawn(position, _monsterHalmerEnemy);

    public Enemy SpawnIron(Vector3 position) =>
        Spawn(position, _ironEnemy);

    public Enemy SpawnExplorel(Vector3 position) =>
        Spawn(position, _explorelEnemy);

    public Enemy SpawnFrost(Vector3 position) =>
        Spawn(position, _frostEnemy);

    public Enemy SpawnRegen(Vector3 position) =>
        Spawn(position, _regenEnemy);
   
    private Enemy Spawn(Vector3 position, Enemy prefab) =>
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