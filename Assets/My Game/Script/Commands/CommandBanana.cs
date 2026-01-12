using UnityEngine;

public class CommandBanana : CheatCommandInfo
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private GunBase _banana;
    [SerializeField] private Player _player;

    public override void Apply()
    {
        _enemy.ReplaceSkin();
        _player.SetGun(_banana);
    }
} 
