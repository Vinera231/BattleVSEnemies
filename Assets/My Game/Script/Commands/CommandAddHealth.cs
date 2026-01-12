using UnityEngine;

public class CommandAddHealth : CheatCommandInfo
{
    [SerializeField] private Health _health;
    [SerializeField] private float _takeHealth;

    public override void Apply() =>
       _health.IncreaseHealth(_takeHealth);
}
