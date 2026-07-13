using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panelGameOverPhase1;
    [SerializeField] private GameObject _panelGameOverPhase2;
    [SerializeField] private WaveManager _waveManager;
    [SerializeField] private PlayerTakeDamage _takeDamage;

    private void Awake() =>   
       HideAll();   

    private void OnEnable() =>  
        _takeDamage.Died += OnDied;
    
    private void OnDisable() =>
        _takeDamage.Died -= OnDied;

    public void Show(bool isFirstPhase)
    {
        _panelGameOverPhase1.SetActive(isFirstPhase);
        _panelGameOverPhase2.SetActive(isFirstPhase == false);
    }

    public void HideAll()
    {
        _panelGameOverPhase1.SetActive(false);
        _panelGameOverPhase2.SetActive(false);
    }
  
    private void OnDied()
    {
        bool isFirstPhase = _waveManager.CurrentWaveIndex <= 10;
        Show(isFirstPhase);
    }
}