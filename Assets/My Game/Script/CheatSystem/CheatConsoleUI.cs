using System;
using UnityEngine;

public class CheatConsoleUI : MonoBehaviour
{
    [SerializeField] private CheatConsolePanel _panel;
    [SerializeField] private CheatEnterButton _button;
    [SerializeField] private CheatInputField _inputField;
    [SerializeField] private CheatInfo _info;

    public event Action<string> CommandEntered;

    private void OnEnable() =>
        _button.Clicked += OnEnterCommand;
    
    private void OnDisable() =>   
        _button.Clicked -= OnEnterCommand;
    
    public void ShowConsole() =>
        _panel.gameObject.SetActive(true);

    public void HideConsole() =>
        _panel.gameObject.SetActive(false);

    public void AddCommandInInfo(string text) =>
        _info.AddInfo(text);

    public void ClearConsole()
    {
        _info.ClearInfo();
        _inputField.ResetText();
    }

    private void OnEnterCommand()
    {
        string text = _inputField.Text;
        _inputField.ResetText();

        CommandEntered?.Invoke(text);
    }
}