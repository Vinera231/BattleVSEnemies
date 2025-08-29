using System;
using UnityEngine;

public class SettingPanelShower : MonoBehaviour
{
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private GameObject _notShoot;
    [SerializeField] private InputReader _inputReader;

    private bool _isShow;

    public event Action<bool> Changed;

    public bool IsActive => _isShow;

    private void Awake() =>
        HidePanel();

    private void OnEnable() =>
        _inputReader.SettingPanelPressed += OnPanelPressed;

    private void OnDisable() =>
        _inputReader.SettingPanelPressed -= OnPanelPressed;

    private void HidePanel()
    {
        Debug.Log($"HidePanel open");
        _notShoot.SetActive(true);
        _settingPanel.SetActive(false);
    }

    private void ShowPanel()
    {
        Debug.Log($"ShowPanel open" );
        _notShoot.SetActive(false);
        _settingPanel.SetActive(true);
    }

    private void OnPanelPressed()
    {
        _isShow = !_isShow;

        if (_isShow)
            ShowPanel();
        else
            HidePanel();

        Debug.Log($"{name} OnPanelPressed ");
        Changed?.Invoke(_isShow);
    }
}