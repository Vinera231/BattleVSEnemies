using UnityEngine;

public class StopGame : MonoBehaviour
{
    [SerializeField] private SettingPanelShower _settingPanel;
    [SerializeField] private ButtonClosePanel _closeButton;
    [SerializeField] private GameObject _notShoot;

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
        _notShoot.SetActive(false);
        Time.timeScale = 0f;
    }

    private void PlayGame()
    {
        _notShoot.SetActive(true);
        Time.timeScale = 1f;
    }
}