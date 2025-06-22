using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode SettingPanel = KeyCode.Q;

    public event Action SettingPanelPressed;

    private void Update()
    {
        ReadSettingPanel();
    }

    private void ReadSettingPanel()
    {
        if (Input.GetKeyDown(SettingPanel))
        SettingPanelPressed?.Invoke();
    }
}