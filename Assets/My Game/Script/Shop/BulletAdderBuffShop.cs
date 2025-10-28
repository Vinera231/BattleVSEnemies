using UnityEngine;

public class BulletAdderBuffShop : Shop
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Sprite _boostSprite;
    [SerializeField] private GameObject _boostPrefab;
    [SerializeField] private int _amountBullet;
    [SerializeField] private int _amountHealth;
    [SerializeField] private Player _player;

    protected override bool TryApplyItem() =>  
        _inventory.TryAddBuff(_boostSprite, KeyCode.F, OnApply);    
   
    private void OnApply()
    {
        if (_player.TryReplenishBullet(_amountBullet))
            Debug.Log($"Игрок получил {_amountBullet} пуль");
        if (_player.TryTakeHealth(_amountHealth))
            Debug.Log($"Игрок получил {_amountBullet} пуль");
    }
}
