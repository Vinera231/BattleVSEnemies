using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanelShower : MonoBehaviour
{
    [SerializeField] private Wave _lastWave;
    [SerializeField] private WinPanel _winPanel;
    [SerializeField] private CursorShower _cursorShower;

    public event Action WinPanelShowed;

    public bool IsActive => _winPanel.gameObject.activeInHierarchy;

    private void Awake() =>
        _winPanel.Hide();

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

        _winPanel.Show();
        WinPanelShowed?.Invoke();
        Invoke(nameof(LoadMenu), 5f);
    }

    private void LoadMenu()
    {
        _cursorShower.Show();
        SceneManager.LoadScene(0);
    }
}