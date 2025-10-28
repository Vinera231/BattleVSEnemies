using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventorySlot _prefab;
    [SerializeField] private Transform _content;
    [SerializeField] private InventorySelector _selector;
    [SerializeField] private int _buffLimit;
    
    private int _buffCount;
    
    private void OnEnable() =>
        _selector.BuffApplied += OnBuffApplied;

    private void OnDisable() =>
        _selector.BuffApplied -= OnBuffApplied;

    public bool TryAddBuff(Sprite sprite, KeyCode hotkey, Action onApply)
    {
        if (_buffCount >= _buffLimit)
            return false;

        _buffCount++;

        InventorySlot inventorySlot = Instantiate(_prefab, _content);
        inventorySlot.Init(sprite, hotkey, onApply);
        _selector.AddSlot(inventorySlot);
        return true;
    }
  
    private void OnBuffApplied() =>   
        _buffCount--;
}