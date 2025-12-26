using UnityEngine;

public class AxeWeaponInstaller : Shop
{
    [SerializeField] private Weapon _weapon;

    protected override bool TryApplyItem()
    {
        _weapon.SetAxe();
        return true;
    }
}