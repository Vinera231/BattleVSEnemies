using System;
using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public event Action<bool> Changed;

    private void Awake() =>
        ShowPanel();

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
