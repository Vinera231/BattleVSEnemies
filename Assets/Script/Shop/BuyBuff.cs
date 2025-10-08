using UnityEngine;

public class BuyBuff : Shop
{
    [SerializeField] private Iventar _iventar;
    [SerializeField] private Sprite _boostSprite;
    [SerializeField] private GameObject _boostPrefab;
    [SerializeField] private BuffType _buffType;

    public enum BuffType
    {
        Bullet,
        Health,
        Damage,
        Other
    }

    protected override bool GiveItem()
    {
        switch (_buffType)
        {
            case BuffType.Bullet:
                return _iventar.PressIventar(_boostPrefab, _boostSprite, isBullet: true);

            case BuffType.Health:
                return _iventar.PressIventar(_boostPrefab,_boostSprite, isHealth: true);

            case BuffType.Other:
                return _iventar.PressIventar(_boostPrefab, _boostSprite);

             case BuffType.Damage:
                return _iventar.PressIventar(_boostPrefab, _boostSprite, isDamage: true);
            default:
                return false;
        }
    }
}