using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode SettingPanel = KeyCode.Q;
    private const KeyCode ExitToMenu = KeyCode.Escape;

    public event Action SettingPanelPressed;
    public event Action ExitToMenuPressed;
    public event Action ShotPressed;

    private void Update()
    {
        ReadSettingPanel();
        ReadExitToMenu();
        ReadShotPressed();
    }

    private void ReadSettingPanel()
    {
        if (Input.GetKeyDown(SettingPanel))
            SettingPanelPressed?.Invoke();
    }

    private void ReadExitToMenu()
    {
        if (Input.GetKeyDown(ExitToMenu))
            ExitToMenuPressed?.Invoke();
    }

    private void ReadShotPressed()
    {
        if (Input.GetMouseButtonDown(0))
            ShotPressed?.Invoke();
    }
}