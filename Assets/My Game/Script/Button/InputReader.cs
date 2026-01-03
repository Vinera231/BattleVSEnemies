using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode SettingPanel = KeyCode.Escape;
    private const KeyCode BuyKey = KeyCode.E;
    private const KeyCode JumpKey = KeyCode.Space;
    private const KeyCode SelectKey = KeyCode.R;
    private const KeyCode BackSelectKey = KeyCode.Q;
    private const KeyCode IventarKey = KeyCode.F;

    public event Action IventarPressed;
    public event Action SettingPanelPressed;
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
}