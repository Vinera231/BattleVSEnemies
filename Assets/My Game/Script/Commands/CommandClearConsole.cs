using UnityEngine;

public class CommandClearConsole : CheatCommandInfo
{
    [SerializeField] private CheatConsoleUI _cheatConsoleUI;

    public override void Apply() =>
        _cheatConsoleUI.ClearConsole();
}
