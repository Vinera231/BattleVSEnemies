using System;
using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
    [SerializeField] private GameObject _notShoot;
    [SerializeField] private GameObject _panel;
    [SerializeField] private ButtonInformer _closeButton;

    public event Action<bool> Changed;

    public bool IsActive => _panel != null && gameObject.activeInHierarchy;

    private void Awake() =>
        ShowPanel();

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
        _notShoot.SetActive(true);
        _panel.SetActive(false);
        Time.timeScale = 1f;
        Changed?.Invoke(true);
    }
  
    private void ShowPanel()
    {
        _notShoot.SetActive(false);
        Time.timeScale = 0f;
        _panel.SetActive(true);
        Changed?.Invoke(false);
    }
}