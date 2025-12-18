using System;
using UnityEngine;

public class CursorShower : MonoBehaviour
{
    [SerializeField] private PauseSwitcher _pauseSwitcher;
    [SerializeField] private RestartGame _restartGame;

    private void Awake()
    {
        _pauseSwitcher.Continued += Hide;
        _pauseSwitcher.Paused += Show;

        if(_pauseSwitcher.IsPaused)      
            Show();
    }

    private void OnEnable() =>  
        _restartGame.OnRestarted += Show;

    private void OnDisable() =>   
        _restartGame.OnRestarted -= Show;
  
    private void OnDestroy()
    {
        _pauseSwitcher.Continued -= Hide;
        _pauseSwitcher.Paused -= Show;
    }

    public void Show()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Hide()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
