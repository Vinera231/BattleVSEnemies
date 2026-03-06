public class BossWave : Wave
{
    private void OnEnable() =>
        Spawner.Spawned += OnEnemySpawned;
    
    private void OnDisable() =>   
        Spawner.Spawned -= OnEnemySpawned;
    
    private void OnEnemySpawned(Enemy enemy) =>  
        InvokeEnemySpawn(enemy);
}