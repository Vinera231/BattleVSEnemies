using UnityEngine;

public class CommandHelp : CheatCommandInfo
{
    [SerializeField] private CheatCommandHandler _handler;

    public override void Apply() =>
        _handler.ShowAllCommands();
}
