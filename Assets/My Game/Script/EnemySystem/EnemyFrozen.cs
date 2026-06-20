
public class EnemyFrozen : Enemy
{
    protected override void Attack()
    {
        SlowComponent?.SlowPlayer();
        base.Attack();
    }
}
