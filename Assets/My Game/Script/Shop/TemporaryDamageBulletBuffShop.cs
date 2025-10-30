using UnityEngine;

public class TemporaryDamageBulletBuffShop : Shop
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Sprite _boostSprite;
    [SerializeField] private int _amountDamage;
    [SerializeField] private int _timeInSeconds;
    [SerializeField] private Player _player;

    protected override bool TryApplyItem() =>
        _inventory.TryAddBuff(_boostSprite, KeyCode.F, OnApply);

    private void OnApply()
    {
        _player.BulletDamage(_amountDamage);
        Debug.Log($"Игрок получил {_amountDamage} пуль");

        Invoke(nameof(ResetBuff),_timeInSeconds);
    }

    private void ResetBuff() =>
        _player.BulletDamage(-_amountDamage);    
}