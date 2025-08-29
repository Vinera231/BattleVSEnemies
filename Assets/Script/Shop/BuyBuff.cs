using UnityEngine;

public class BuyBuff : Shop
{
    [SerializeField] private Iventar _iventarPrefab;
    [SerializeField] private Sprite _boostSprite;

    protected override bool GiveItem()
    {
        _iventarPrefab.PressIventar(gameObject, _boostSprite,true);
        return true; 
    }
}