using UnityEngine;

public class HealthPotionBuffShop : Shop
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Sprite _boostSprite;
    [SerializeField] private int _amountHealth;
    [SerializeField] private Player _player;

    protected override bool TryApplyItem() =>
        _inventory.TryAddBuff(_boostSprite,Key, OnApply);

    private void OnApply()
    {
        if (_player.TryTakeHealth(_amountHealth))
            Debug.Log($"Игрок получил {_amountHealth} пуль");
    }
}