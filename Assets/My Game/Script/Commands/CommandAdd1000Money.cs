using UnityEngine;

public class CommandAdd1000Money : CheatCommandInfo
{
    public override void Apply() =>
        Debug.Log("Добавлено 1000 денег");
}