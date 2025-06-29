using UnityEngine;

public class StopGame : MonoBehaviour
{
    [SerializeField] private SettingPanelShower _settingPanel;

    private void OnEnable()
    {
        _settingPanel.Changed += OnSettingChanged;
    }

    private void OnDisable()
    {
        _settingPanel.Changed -= OnSettingChanged;
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