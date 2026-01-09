using UnityEngine;

public class CommandBratkevich : CheatCommandInfo
{
    public override void Apply() =>
       Debug.Log("Да это я создатель игры :)");
}