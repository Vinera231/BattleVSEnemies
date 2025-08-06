using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode SettingPanel = KeyCode.Escape;
    private const KeyCode BuyKey = KeyCode.E;
    private const KeyCode JumpKey = KeyCode.Space;

    public event Action SettingPanelPressed;
    public event Action ShotPressed;
    public event Action BuyPressed;
    public event Action JumpPressed;

    private void Update()
    {
        ReadSettingPanel();
        ReadShotPressed();
        ReadBuyKey();
        ReadJumpKey();
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

    private void ReadBuyKey()
    {
        if (Input.GetKeyDown(BuyKey))
            BuyPressed?.Invoke();
    }

    private void ReadJumpKey()
    {
        if (Input.GetKeyDown(JumpKey))
            JumpPressed?.Invoke();
    }
}