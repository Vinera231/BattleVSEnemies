using UnityEngine;

public class CommandBanana : CheatCommandInfo
{
    [SerializeField] private Enemy _enemy;

    public override void Apply() =>
        _enemy.Minion();  
} 
