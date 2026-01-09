using System;
using UnityEngine;

public class CursorShower : MonoBehaviour
{
    [SerializeField] private PauseSwitcher _pauseSwitcher;
    [SerializeField] private RestartGame _restartGame;
    [SerializeField] private ChitingPanelShower _chitingPanelShower;

    private void Awake()
    {
        _pauseSwitcher.Continued += Hide;
        _pauseSwitcher.Paused += Show;
        _chitingPanelShower.OpenCursour += Show;
        _restartGame.OnRestarted += Show;
        
        if(_pauseSwitcher.IsPaused)      
            Show();
    }

    //private void OnEnable() =>
       
    

    //private void OnDisable() =>   
          
  
    private void OnDestroy()
    {
         _restartGame.OnRestarted -= Show;
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
