using UnityEngine;

public class BulletAdderBuffShop : Shop
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Sprite _boostSprite;
    [SerializeField] private int _amountBullet;
    [SerializeField] private Player _player;

    protected override bool TryApplyItem() =>
        _inventory.TryAddBuff(_boostSprite, Key, OnApply);

    private void OnApply()
    {
        if (_player.TryReplenishBullet(_amountBullet))
            Debug.Log($"Игрок получил {_amountBullet} пуль");
    }
}
