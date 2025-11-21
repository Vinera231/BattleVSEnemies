using UnityEngine;

public class SpeedPotionBuffShop : Shop
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Sprite _boostSprite;
    [SerializeField] private int _amountSpeed;
    [SerializeField] private int _timeInSeconds;
    [SerializeField] private Player _player;
   
    protected override bool TryApplyItem() =>
           _inventory.TryAddBuff(_boostSprite, KeyCode.F, OnApply);
   
    private void OnApply()
    {
        _player.IncreaseSpeed(_amountSpeed);
        Invoke(nameof(ResetBuff), _timeInSeconds);
    }

    private void ResetBuff()
    {
        _player.ReseteToBaseSpeed(_amountSpeed); 
        Debug.Log($"время прошло {_amountSpeed} ResetBuff ");
    }
}