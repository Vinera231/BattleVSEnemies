using UnityEngine;

public class CommandNiger : CheatCommandInfo
{
    [SerializeField] private Player _player;
    public override void Apply() =>
        _player.ChangedColor();
       
}