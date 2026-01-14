using System;
using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;

public class InputReader : MonoBehaviour
{
    private const KeyCode SettingPanel = KeyCode.Escape;
    private const KeyCode ChitingPanel = KeyCode.BackQuote;
    private const KeyCode EnterCheatPanel = KeyCode.KeypadEnter;
    private const KeyCode BuyKey = KeyCode.Space;
    private const KeyCode JumpKey = KeyCode.Space;
    private const KeyCode SelectKey = KeyCode.E;
    private const KeyCode BackSelectKey = KeyCode.Q;
    private const KeyCode IventarKey = KeyCode.V;

    public event Action IventarPressed;
    public event Action SettingPanelPressed;
    public event Action ChitingPanelPressed;
    public event Action EnterCheatPanelPressed;
    public event Action ShotPressed;
    public event Action ShotUnpressed;
    public event Action SecondWeaponPressed;
    public event Action SecondWeaponUnpressed;
    public event Action BuyPressed;
    public event Action JumpPressed;
    public event Action SelectPressed;
    public event Action BackSelectPressed;

    private void Update()
    {
        ReadSettingPanel();
        ReadChitingPanel();
        ReadEnterCheatPanel();
        ReadShotPressed();
        ReadBuyKey();
        ReadJumpKey();
        ReadSelectKey();
        ReadIventarKey();
        ReadSecondWeapon();
    }

    private void ReadSecondWeapon()
    {
        if (Input.GetMouseButtonDown(1))
            SecondWeaponPressed?.Invoke();

        if (Input.GetMouseButtonUp(1))
            SecondWeaponUnpressed?.Invoke();
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

        if (Input.GetMouseButtonUp(0))
            ShotUnpressed?.Invoke();
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
        if (Input.GetKeyDown(SelectKey))
            SelectPressed?.Invoke();

        if (Input.GetKeyDown(BackSelectKey))
            BackSelectPressed?.Invoke();
    }

    private void ReadIventarKey()
    {
        if (Input.GetKeyDown(IventarKey))
            IventarPressed?.Invoke();
    }
   
    private void ReadChitingPanel()
    {
        if (Input.GetKeyDown(ChitingPanel))
           ChitingPanelPressed?.Invoke();
    }

    private void ReadEnterCheatPanel()
    {
        if (Input.GetKeyDown(EnterCheatPanel))
            EnterCheatPanelPressed?.Invoke();
    }

}