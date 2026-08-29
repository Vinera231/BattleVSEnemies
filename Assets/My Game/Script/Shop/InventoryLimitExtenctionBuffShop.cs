using UnityEngine;

public class InventoryLimitExtenctionBuffShop : Shop
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private int _countSlots;

    protected override bool TryApplyItem()
    {
        _inventory.IncreaseLimit(_countSlots);
        return true;
    }
}