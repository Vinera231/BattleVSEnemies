using System;
using UnityEngine;

[Serializable]
public abstract class CheatCommandInfo : MonoBehaviour, ICheatCommand
{
    [SerializeField] private string _command;
    [SerializeField] private string _description;
    [SerializeField] private string _consoleInfo;

    public string Command => _command;

    public string Description => _description;

    public string ConsoleInfo => _consoleInfo;

    public abstract void Apply();

    public override string ToString() =>
        $"{_command} - {_description}";
}
