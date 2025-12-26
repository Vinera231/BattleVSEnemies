using UnityEngine;

public class SawWeaponInstaller : Shop
{
    [SerializeField] private Weapon _weapon;

    protected override bool TryApplyItem()
    {
        _weapon.SetSaw();
        return true;
    }
}