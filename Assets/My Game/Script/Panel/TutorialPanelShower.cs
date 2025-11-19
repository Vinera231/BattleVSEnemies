using System;
using UnityEngine;

public class TutorialPanelShower : MonoBehaviour
{
    [SerializeField] private TutorialPanel _panel;
    [SerializeField] private ButtonInformer _closeButton;

    public bool IsActive => _panel != null && _panel.gameObject.activeSelf;

    private void Start() =>
      _panel.Show();

    private void OnEnable()
    {
        _closeButton.Clicked += HidePanel;
    }

    private void OnDisable()
    {
        _closeButton.Clicked -= HidePanel;
    }

    private void HidePanel()
    {
        if (_panel.gameObject.activeSelf == false)
            return;

        _panel.Hide();
    }
}