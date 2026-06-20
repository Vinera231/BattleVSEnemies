using UnityEngine;

public class SpeedPotionBuffShop : Shop
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Sprite _boostSprite;
    [SerializeField] private int _amountSpeed;
    [SerializeField] private int _timeInSeconds;
    [SerializeField] private PlayerMovement _movement;

    protected override bool TryApplyItem() =>
           _inventory.TryAddBuff(_boostSprite,Key, OnApply);

    private void OnApply()
    {
        _movement.IncreaseSpeed(_amountSpeed);
        Invoke(nameof(ResetBuff), _timeInSeconds);
    }

    private void ResetBuff() =>  
        _movement.ResetToBaseSpeed(_amountSpeed);
}