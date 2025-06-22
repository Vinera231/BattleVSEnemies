using UnityEngine;

public class CursorShower : MonoBehaviour
{
    [SerializeField] private SettingPanelShower _settingPanel;
    [SerializeField] private PlayerControler _playerControler;
    [SerializeField] private PlayerControler _player;
    [SerializeField] private InputReader _inputReader;

    private void Awake() => 
        Hide();

    private void OnEnable()
    {
        _settingPanel.Changed += OnChanged;
        _player.Died += Show;
        _inputReader.ExitToMenuPressed += Show;
    }

    private void OnDisable()
    {
        _settingPanel.Changed -= OnChanged;
        _player.Died -= Show;
        _inputReader.ExitToMenuPressed -= Show;
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