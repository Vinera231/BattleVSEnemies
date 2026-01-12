using UnityEngine;

public class RegenEnemy : Enemy
{
    private readonly float _recoveryHealthPerSecond = 10f;
    private readonly float _recoveryHealthAfterAttack = 20f;

    protected override void Update()
    {
        base.Update();
        HealthComponent.RecoverHealth(_recoveryHealthPerSecond * Time.deltaTime);
    }

    protected override void Attack(Player player)
    {
        base.Attack(player);
        HealthComponent.RecoverHealth(_recoveryHealthAfterAttack);
    }
}