using System;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField] private WinPanel _winPanel;
    [SerializeField] private WaveManager _waveManager;

    public event Action WinPanelShowed;

    private void Awake()
    {
        _winPanel.Hide();
    }

    private void OnEnable()
    {
        _waveManager.AllWavesFinished += OnWavesFinished;
    }

    private void OnDisable()
    {
        _waveManager.AllWavesFinished -= OnWavesFinished;
    }

    private void OnWavesFinished()
    {
        _winPanel.Show();
        WinPanelShowed?.Invoke();
    }
}