using UnityEngine;

public class CommandExitGame : CheatCommandInfo
{
    public override void Apply() =>
    Application.Quit();
}