using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode SettingPanel = KeyCode.Escape;
    private const KeyCode BuyKey = KeyCode.Q;
    private const KeyCode JumpKey = KeyCode.Space;
    private const KeyCode SelectKey = KeyCode.E;
    private const KeyCode IventarKey = KeyCode.F;

    public event Action IventarPressed;
    public event Action SettingPanelPressed;
    public event Action ShotPressed;
    public event Action BuyPressed;
    public event Action JumpPressed;
    public event Action SelectPressed;


    private void Update()
    {
        ReadSettingPanel();
        ReadShotPressed();
        ReadBuyKey();
        ReadJumpKey();
        ReadSelectKey();
        ReadIventarKey();
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

    private void ReadSelectKey()
    {
       if(Input.GetKeyDown(SelectKey))
            SelectPressed?.Invoke();
    }

    private void ReadIventarKey()
    {
        if( Input.GetKeyDown(IventarKey))
            IventarPressed?.Invoke();
    }

}