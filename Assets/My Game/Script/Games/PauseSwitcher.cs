using System;
using UnityEngine;

public class PauseSwitcher : MonoBehaviour
{
    private int _pauseCounter = 0;

    public event Action Paused;
    public event Action Continued;

    public static PauseSwitcher Instance { get; private set; }

    public bool IsPaused => _pauseCounter > 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);

            return;
        }

        Destroy(gameObject);
    }

    public void PauseGame()
    {
        _pauseCounter++;
        HandleChanged();
    } 
    
    public void PlayGame()
    {
        _pauseCounter--;
        HandleChanged();
    }  

    private void HandleChanged()
    {
        if(_pauseCounter <= 0)
        {
            Time.timeScale = 1f;
            Continued?.Invoke();
        }
        else  
        {
            Time.timeScale = 0f;
            Paused?.Invoke();
        }
    }
}