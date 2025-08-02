using System;
using UnityEngine;

public class CursorShower : MonoBehaviour
{
    [SerializeField] private TutorialPanel _tutorialPanel;
    [SerializeField] private WinPanelShower _winPanelShower;
    [SerializeField] private SettingPanelShower _settingPanel;
    [SerializeField] private Player _player;
    [SerializeField] private InputReader _inputReader;

    public event Action OnCursourShow;
    public event Action OnCursourHide;

    private void OnEnable()
    {
        _winPanelShower.WinPanelShowed += Show;
        _settingPanel.Changed += OnChanged;
        _tutorialPanel.Changed += OnChanged;
        _player.Died += Show;        
    }

    private void OnDisable()
    {
        _winPanelShower.WinPanelShowed -= Show;
        _settingPanel.Changed -= OnChanged;
        _tutorialPanel.Changed -= OnChanged;
        _player.Died -= Show;
    }

    private void OnChanged(bool isOn)
    {
        if (isOn)
            Show();
        else
            Hide();
    }

    private void Show()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        OnCursourShow?.Invoke();
    }

    private void Hide()
    {
        if(_tutorialPanel.IsActive || _winPanelShower.IsActive || _settingPanel.IsActive)
            return;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        OnCursourHide?.Invoke();
    }
}