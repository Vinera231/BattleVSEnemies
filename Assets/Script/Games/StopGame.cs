using UnityEngine;

public class StopGame : MonoBehaviour
{
    [SerializeField] private SettingPanelShower _settingPanel;
    [SerializeField] private ButtonClosePanel _closeButton;

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
        Time.timeScale = 0;
    }

    private void PlayGame()
    {
        Time.timeScale = 1;
    }

}