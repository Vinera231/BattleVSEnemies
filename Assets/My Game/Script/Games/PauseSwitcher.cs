using System;
using UnityEngine;

public class PauseSwitcher : MonoBehaviour
{
    private int _pauseCounter = 0;
    private bool _paused = false;

    public event Action Paused;
    public event Action Continued;

    public bool IsPaused => _paused;

    private void Awake()
    {
        _paused = false;
        Time.timeScale = 1f;
    }
   
    public void PauseGame(GameObject _)
    {
        Debug.Log("PauseGame");
        _pauseCounter++;
        HandleChanged();
    } 
    
    public void PlayGame(GameObject _)
    {
        _pauseCounter--;
        HandleChanged();
    }  

    private void HandleChanged()
    {
        if(_pauseCounter <= 0)
        {
            if (_paused == false)
                return;

            _paused = false;
            Time.timeScale = 1f;
            Continued?.Invoke();
        }
        else  
        {
            if (_paused)
                return;
            
            _paused = true;
            Time.timeScale = 0f;
            Paused?.Invoke();
        }
    }
}