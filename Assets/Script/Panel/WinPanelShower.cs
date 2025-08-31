using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanelShower : MonoBehaviour
{
    [SerializeField] private Wave _lastWave;
    [SerializeField] private WinPanel _winPanel;

    public event Action WinPanelShowed;

    public bool IsActive => _winPanel.gameObject.activeInHierarchy;

    private void Awake() =>
        _winPanel.gameObject.SetActive(false);

    private void OnEnable()
    {
        _lastWave.Finished += OnFinished;
    }

    private void OnDisable()
    {
        _lastWave.Finished -= OnFinished;
    }

    private void OnFinished()
    {
        Debug.Log($"{name} OnFinished ");

        _winPanel.gameObject.SetActive(true);
        WinPanelShowed?.Invoke();
        Invoke(nameof(LoadMenu), 6f);
    }

    private void LoadMenu() =>
        SceneManager.LoadScene(0);
}