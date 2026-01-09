using UnityEngine;

public class InventoryLimitExtenctionBuffShop : Shop
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Sprite _boostSprite;
    [SerializeField] private int _countSlots;

    protected override bool TryApplyItem() =>
        _inventory.TryAddBuff(_boostSprite, Key, OnApply);

    private void OnApply() => 
        _inventory.IncreaseLimit(_countSlots);   
}