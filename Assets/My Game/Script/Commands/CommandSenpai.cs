using UnityEngine;

public class CommandSenpai : CheatCommandInfo
{
    [SerializeField] SfxPlayer _player;

    public override void Apply() =>
     _player.PlayAhhSound();
} 