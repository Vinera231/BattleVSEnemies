using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static BoostDate;

public class Iventar : MonoBehaviour
{ 
    //last version
    [SerializeField] private InputReader _reader;
    [SerializeField] private Player _player;
    [SerializeField] private int _amountBullet;
    [SerializeField] private int _amountHealth;
    [SerializeField] private int _amountDamage = 30;
    [SerializeField] private float _damageDirection = 5f;
    [SerializeField] private Image _boostImageUI;
    [SerializeField] private Transform _inventoryUIParent;
    [SerializeField] private GameObject _slotPrefab;
   
    private List<BoostDate> _boost = new();
    
    private Sprite _currentBoostSprite;
    private GameObject _currentBoost;
    private bool _hasBoost;

    private void OnEnable()
    {
        _reader.IventarPressed += UseFirstBoost;
    }
   
    private void OnDisable()
    {
        _reader.IventarPressed -= UseFirstBoost;
    }

    public void AddIventar()
    {
        GameObject slotObj = Instantiate(_slotPrefab, _inventoryUIParent);
        Image slotImage = slotObj.GetComponent<Image>();
        _boost.Add(new BoostDate(null, slotImage, BoostType.None));
    }

    public bool PressIventar(GameObject currentboostPrefab, Sprite currentboostSprite, bool isBullet = false, bool isHealth = false, bool isDamage = false)
    {
        if (_hasBoost)
            return false;
        BoostType type = BoostType.None;
        if (isBullet) type = BoostType.Bullet;
        else if (isHealth) type = BoostType.Health;
        else if (isDamage) type = BoostType.Damage;
        else type = BoostType.Object;
        AddIventar();

        BoostDate freeSlot = _boost.Find(b =>b.Type == BoostType.None);
      
         _currentBoost = currentboostPrefab;
        _currentBoostSprite = currentboostSprite;
        _hasBoost = true;

        freeSlot.Prefab = currentboostPrefab;
        freeSlot.Type = type;
        freeSlot.Icon.sprite = currentboostSprite;
        freeSlot.Icon.enabled = true;

        if (_currentBoostSprite != null)
        {
            Debug.Log($"PressIventar = {currentboostSprite}");
            _boostImageUI.sprite = _currentBoostSprite;
            _boostImageUI.enabled = true;
        }

        Debug.Log($"Boost {_currentBoost.name}");
        return true;
    }

    private void UseFirstBoost()
    {
        BoostDate slot = _boost.Find(b => b.Type != BoostType.None);
        UseBoost(slot);
        slot.Clear();
    }

    private void UseBoost(BoostDate boost)
    {
        switch (boost.Type)
        {
            case BoostType.Bullet:
                if (_player.TryReplenishBullet(_amountBullet))
                    Debug.Log($"Игрок получил {_amountBullet} пуль");
                break;

            case BoostType.Health:
                if (_player.TryTakeHealth(_amountHealth))
                    Debug.Log($"Игрок восстановил {_amountHealth} HP");
                break;

            case BoostType.Damage:
                StartCoroutine(TryTakeDamage());
                break;

            case BoostType.Object:
                Instantiate(boost.Prefab, transform.position, Quaternion.identity);
                Debug.Log($"Создан объект {boost.Prefab.name}");
                break;
        }
    }
    private IEnumerator TryTakeDamage()
    {
        _player.IncreaseBulletDamage(_amountDamage);

        yield return new WaitForSeconds(_damageDirection);

        _player.IncreaseBulletDamage(-_amountDamage);
    }
}

[System.Serializable]
public class BoostDate : MonoBehaviour
{
    public GameObject Prefab;
    public Image Icon;
    public BoostType Type;

    public BoostDate(GameObject prefab,Image icon, BoostType type)
    {
        Prefab = prefab;
        Icon = icon;
        Type = type;
    }

    public void Clear()
    {
        Prefab = null;
        Type = BoostType.None;
        if (Icon != null)
        {
            Icon.enabled = false;
            Icon.sprite = null;
        }
    }
      public enum BoostType { None, Bullet, Health, Damage, Object }
}