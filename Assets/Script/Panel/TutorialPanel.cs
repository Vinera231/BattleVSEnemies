using System;
using TMPro.EditorUtilities;
using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private ButtonInformer _closeButton;

    public event Action<bool> Changed;
    
    public bool IsActive => _panel.gameObject.activeInHierarchy;

    private void Awake() =>
        ShowPanel();

    private void OnEnable() =>
        _closeButton.Clicked += HidePanel;

    private void OnDisable() =>
        _closeButton.Clicked -= HidePanel;

    private void HidePanel()
    {
        _panel.SetActive(false);
        Time.timeScale = 1f;
        Changed?.Invoke(false);
    }

    private void ShowPanel()
    {
        Time.timeScale = 0f;
        _panel.SetActive(true);
        Changed?.Invoke(false);
    }
}
