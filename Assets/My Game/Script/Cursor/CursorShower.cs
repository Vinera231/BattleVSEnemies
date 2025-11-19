using System;
using UnityEngine;

public class CursorShower : MonoBehaviour
{
    [SerializeField] private PauseSwitcher _pauseSwitcher;

    public event Action OnCursourShow;
    public event Action OnCursourHide;

    private void Awake()
    {
        _pauseSwitcher.Continued += Hide;
        _pauseSwitcher.Paused += Show;

        if(_pauseSwitcher.IsPaused)      
            Show();
    }

    private void OnDestroy()
    {
        _pauseSwitcher.Continued -= Hide;
        _pauseSwitcher.Paused -= Show;
    }

    public void Show()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        OnCursourShow?.Invoke();
    }

    private void Hide()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        OnCursourHide?.Invoke();
    }
}