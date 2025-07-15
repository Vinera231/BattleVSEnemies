using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode SettingPanel = KeyCode.Escape;

    public event Action SettingPanelPressed;
    public event Action ExitToMenuPressed;
    public event Action ShotPressed;

    private void Update()
    {
        ReadSettingPanel();
        ReadShotPressed();
    }

    private void ReadSettingPanel()
    {
        if (Input.GetKeyDown(SettingPanel))
            SettingPanelPressed?.Invoke();
    }
    
    private void ReadShotPressed()
    {
        if (Input.GetMouseButtonDown(0))
            ShotPressed?.Invoke();
    }

}
