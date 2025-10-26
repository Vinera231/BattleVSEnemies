using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IventarSlot : MonoBehaviour
{
    [SerializeField] private InputReader _reader;
    [SerializeField] private Player _player;
    [SerializeField] private Transform _iventarUI;
    [SerializeField] private GameObject _iventarSlotPrefab;

    private List<Iventar> _slots = new();

    public void BuyInventorySlot()
    {
        GameObject slotObj = Instantiate(_iventarSlotPrefab, _iventarUI);
        Iventar slot = slotObj.GetComponent<Iventar>();
        _slots.Add(slot);
    }

    public bool AddBoost(GameObject boostPrefab,Sprite boostSprite,bool isBullet = false,bool isHealth = false, bool isDamage = false)
    {
     //   IventarSlot freeSlot = _slots.Find(s => !s._hasBoost);
        
       // freeSlot.AddBoost(boostPrefab,boostSprite,isBullet,isHealth,isDamage);
        return true;
    }

    //private void UseFirstAvailableBoost()
    //{
    //    foreach(var slot in _slots)
    //    {
    //        if (slot._hasBoost)
    //        {
    //            slot.UseBoost(_player);
    //            return;
    //        }
    //    }
    //}


}