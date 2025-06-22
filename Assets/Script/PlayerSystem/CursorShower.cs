using UnityEngine;

public class CursorShower : MonoBehaviour
{
    [SerializeField] private SettingPanelShower _settingPanel;
    [SerializeField] private PlayerControler _playerControler;

    private void Awake() => 
        Hide();

    private void OnEnable()
    {
        _settingPanel.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _settingPanel.Changed -= OnChanged;
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