using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private ButtonClosePanel _closePanel;
    [SerializeField] private bool _hiddenCursor = true;

    private void OnEnable()
    {
        _closePanel.PanelClosed += Hide;

        if (_hiddenCursor)
        {
            CursorShower.Instance.Show();
            PauseSwitcher.Instance.PauseGame();
        }
    }

    private void OnDisable()
    {
        _closePanel.PanelClosed -= Hide;

        if (_hiddenCursor)
        {
            CursorShower.Instance.Hide();
            PauseSwitcher.Instance.PlayGame();
        }
    }

    public void Show() =>
        gameObject.SetActive(true);

    public void Hide() =>
        gameObject.SetActive(false);
}