using UnityEngine;

public class TemporaryDamageBulletBuffShop : Shop
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Sprite _boostSprite;
    [SerializeField] private int _amountDamage;
    [SerializeField] private int _timeInSeconds;
    [SerializeField] private PlayerShooting _player;

    protected override bool TryApplyItem() =>
        _inventory.TryAddBuff(_boostSprite, Key, OnApply);

    private void OnApply()
    {
        _player.IncreaseBulletDamage(_amountDamage);

        Invoke(nameof(ResetBuff),_timeInSeconds);
    }

    private void ResetBuff() =>
        _player.IncreaseBulletDamage(-_amountDamage);    
}
