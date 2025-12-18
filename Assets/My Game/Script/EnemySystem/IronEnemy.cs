
public class IronEnemy : Enemy
{
    private float _lowDamage = 0.5f; 

    public override void TakeDamage(float damage)
    {
        float redused = damage * _lowDamage;
        base.TakeDamage(redused);
    }
}
