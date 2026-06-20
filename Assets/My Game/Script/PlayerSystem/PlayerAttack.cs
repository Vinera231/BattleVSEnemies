using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private List<MonoBehaviour> _secondWeapons;
    private int _allowedAttackCount = 1;
    public void SecondAttackPressed()
    {
        if (PauseSwitcher.Instance.IsPaused)
            return;

        if (_allowedAttackCount <= 0)
            return;

        foreach (MonoBehaviour weapon in _secondWeapons)
            if (weapon.gameObject.activeSelf)
                if (weapon is ISecondWeapon secondWeapon)
                    secondWeapon.Attack();
    }

    public void SecondAttackUnpressed()
    {
        foreach (MonoBehaviour weapon in _secondWeapons)
            if (weapon.gameObject.activeSelf)
                if (weapon is Saw saw)
                    saw.StopRotation();
    }
}