using UnityEngine;

public class CheatCommandHandler : MonoBehaviour
{
    [SerializeField] private CheatConsoleUI _cheatConsole;
    [SerializeField] private Color _acceptColor;
    [SerializeField] private Color _unknownColor;
    [SerializeField, TextArea] private string _unknownCommandText;
    [SerializeField] private CheatCommandInfo[] _commands;

    private void OnEnable() =>
        _cheatConsole.CommandEntered += OnCommandEntered;

    private void OnDisable() =>
        _cheatConsole.CommandEntered -= OnCommandEntered;

    public void ShowAllCommands()
    {
        string text = string.Empty;

        foreach (CheatCommandInfo command in _commands)
            text += $"\n{command}";

        _cheatConsole.AddCommandInInfo(text);
    }
   
    private void OnCommandEntered(string command)
    {
        if (string.IsNullOrEmpty(command))
            return;

        bool isSuccesfull = false;
        CheatCommandInfo cheatCommandInfo = null;

        foreach (CheatCommandInfo info in _commands)
        {
            if (info.Command == command)
            {
                isSuccesfull = true;
                cheatCommandInfo = info;

                break;
            }
        }

        string newText;

        if (isSuccesfull)
            newText = WrapInColor(cheatCommandInfo.ConsoleInfo, _acceptColor);
        else
            newText = string.Format(_unknownCommandText, WrapInColor(command, _unknownColor));

        _cheatConsole.AddCommandInInfo(newText);

        if (isSuccesfull)
            cheatCommandInfo.Apply();
    }

    private string WrapInColor(string text, Color color)
    {
        string hexColor = ColorUtility.ToHtmlStringRGBA(color);

        return $"<color=#{hexColor}>{text}</color>";
    }
}