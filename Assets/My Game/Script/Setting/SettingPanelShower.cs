using System;
using UnityEngine;

public class SettingPanelShower : MonoBehaviour
{
    [SerializeField] private SettingsPanel _settingPanel;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private ButtonClosePanel _closeButton;

    private bool _isShow;

    public event Action<bool> Changed;

    public bool IsActive => _isShow;

    private void Awake() =>
        HidePanel();

    private void OnEnable()
    {
        _inputReader.SettingPanelPressed += OnPanelPressed;
        _closeButton.PanelClosed += HidePanel;
    }

    private void OnDisable()
    {
        _inputReader.SettingPanelPressed -= OnPanelPressed;
        _closeButton.PanelClosed -= HidePanel;
    }

    private void HidePanel()
    {
        if (_settingPanel.gameObject.activeSelf == false)
            return;

        _settingPanel.Hide();
    }

    private void ShowPanel()
    {
        if (_settingPanel.gameObject.activeSelf)
            return;

       _settingPanel.Show();
    }

    private void OnPanelPressed()
    {
        _isShow = !_isShow;

        if (_isShow)
            ShowPanel();
        else
            HidePanel();

        Changed?.Invoke(_isShow);
    }
}