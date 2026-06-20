using UnityEngine;

public class RegenEnemy : Enemy
{
    [SerializeField] private float _recoveryHealthPerSecond = 10f;
    [SerializeField] private float _recoveryHealthAfterAttack = 20f;

    protected override void Update()
    {
        base.Update();
        HealthComponent.RecoverHealth(_recoveryHealthPerSecond * Time.deltaTime);
    }

    protected override void Attack()
    {
        base.Attack();
        HealthComponent.RecoverHealth(_recoveryHealthAfterAttack);
    }
}