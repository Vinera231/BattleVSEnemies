using UnityEngine;

public class BulletAdderBuffShop : Shop
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Sprite _boostSprite;
    [SerializeField] private int _amountBullet;
    [SerializeField] private PlayerShooting _player;

    protected override bool TryApplyItem() =>
        _inventory.TryAddBuff(_boostSprite, Key, OnApply);

    private void OnApply() =>
        _player.TryReplenishBullet(_amountBullet);
}