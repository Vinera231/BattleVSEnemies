using System;
using UnityEngine;

public class PauseSwitcher : MonoBehaviour
{
    [SerializeField] private SettingPanelShower _settingPanel;
    [SerializeField] private ButtonClosePanel _closeButton;

    public event Action Paused;
    public event Action Continued;

    private void OnEnable()
    {
        _settingPanel.Changed += OnSettingChanged;
        _closeButton.PanelClosed += PlayGame;
    }

    private void OnDisable()
    {
        _settingPanel.Changed -= OnSettingChanged;
        _closeButton.PanelClosed -= PlayGame;
    }

    private void OnSettingChanged(bool isOn)
    {
        if (isOn)
            PauseGame();
        else
            PlayGame();
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        Paused?.Invoke();
    } 
    
    private void PlayGame()
    {
        Time.timeScale = 1f;  
        Continued?.Invoke();
    }  
}