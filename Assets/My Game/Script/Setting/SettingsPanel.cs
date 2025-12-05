using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private PauseSwitcher _pauseSwitcher;
    [SerializeField] private ButtonClosePanel _closePanel;

    private void OnEnable()
    {
        _pauseSwitcher.PauseGame(gameObject);
        _closePanel.PanelClosed += Hide;
    }

    private void OnDisable()
    {
        _pauseSwitcher.PlayGame(gameObject);
        _closePanel.PanelClosed -= Hide;
    }

    public void Show() =>
        gameObject.SetActive(true);

    public void Hide() =>
        gameObject.SetActive(false);
}
