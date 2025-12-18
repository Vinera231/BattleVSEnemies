
public class EnemyFrozen : Enemy
{
    protected override void Attack(Player player)
    {
        player.SlowPlayer();
        base.Attack(player);
        
    }
}
