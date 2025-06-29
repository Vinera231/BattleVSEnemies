using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode SettingPanel = KeyCode.Escape;

    public event Action SettingPanelPressed;
    public event Action ShotPressed;
    public event Action ExitToMenuPressed;

    private void Update()
    {
        ReadSettingPanel();
        ReadShotPressed();
    }

    private void ReadSettingPanel()
    {
        if (Input.GetKeyDown(SettingPanel))
            SettingPanelPressed?.Invoke();
            ExitToMenuPressed?.Invoke();
    }

    private void ReadShotPressed()
    {
        if (Input.GetMouseButtonDown(0))
            ShotPressed?.Invoke();
    }

}