using UnityEngine;

public class CursorShower : MonoBehaviour
{
    [SerializeField] private PanelSwitcher _panelSwitcher;
    [SerializeField] private SettingPanelShower _settingPanel;
    [SerializeField] private Player _player;
    [SerializeField] private InputReader _inputReader;

    private void Awake() => 
        Hide();

    private void OnEnable()
    {
        _panelSwitcher.WinPanelShowed += Show;
        _settingPanel.Changed += OnChanged;
        _player.Died += Show;
    }

    private void OnDisable()
    {
        _panelSwitcher.WinPanelShowed -= Show;
        _settingPanel.Changed -= OnChanged;
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
    }

    private void Hide()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}