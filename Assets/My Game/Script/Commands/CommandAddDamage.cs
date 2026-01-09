using UnityEngine;

public class CommandAddDamage : CheatCommandInfo
{
    [SerializeField] private BulletSpawner _spawner;
    [SerializeField] private float _takeDamage;

    public override void Apply() =>
       _spawner.IncreaseBulletDamage(_takeDamage);
}
