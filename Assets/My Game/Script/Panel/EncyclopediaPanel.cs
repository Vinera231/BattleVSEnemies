using UnityEngine;

public class EncyclopediaPanel : MonoBehaviour
{
    [SerializeField] private ButtonClosePanel _closePanel;

    private void OnEnable()
    {
        _closePanel.PanelClosed += Hide;
    }
    private void OnDisable()
    {
        _closePanel.PanelClosed -= Hide;
    }

    private void Hide()
    {
       gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}