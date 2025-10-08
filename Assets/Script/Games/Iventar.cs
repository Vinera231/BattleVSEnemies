using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Iventar : MonoBehaviour
{
    [SerializeField] private InputReader _reader;
    [SerializeField] private Player _player;
    [SerializeField] private int _amountBullet;
    [SerializeField] private int _amountHealth;
    [SerializeField] private int _amountDamage = 30;
    [SerializeField] private float _damageDirection = 5f;
    [SerializeField] private Image _boostImageUI;

    private Sprite _currentBoostSprite;
    private GameObject _currentBoost;
    private bool _hasBoost;
    private bool _isBulletBoost;
    private bool _isHealthBoost;
    private bool _isDamageBoost;
    private bool _isUsed = false;

    private void OnEnable()
    {
        _reader.IventarPressed += UseBoost;
    }

    private void OnDisable()
    {
        _reader.IventarPressed -= UseBoost;
    }

    public bool PressIventar(GameObject currentboostPrefab, Sprite currentboostSprite, bool isBullet = false, bool isHealth = false, bool isDamage = false)
    {
        if (_hasBoost)
            return false;

        _currentBoost = currentboostPrefab;
        _currentBoostSprite = currentboostSprite;
        _hasBoost = true;
        _isBulletBoost = isBullet;
        _isHealthBoost = isHealth;
        _isDamageBoost = isDamage;

        if (_currentBoostSprite != null)
        {
            Debug.Log($"PressIventar = {currentboostSprite}");
            _boostImageUI.sprite = _currentBoostSprite;
            _boostImageUI.enabled = true;
        }

        Debug.Log($"Boost {_currentBoost.name}");
        return true;
    }

    private void UseBoost()
    {
        if (_hasBoost && _currentBoost != null)
        {
            if (_isBulletBoost)
            {
                if (_player != null && _player.TryReplenishBullet(_amountBullet))
                {
                    _isUsed = true;
                    Debug.Log($"Player take {_amountBullet}Bullet");
                }
                else
                {
                    Debug.Log("патроны полние");
                }
            }
            else if (_isHealthBoost)
            {
                if (_player != null && _player.TryTakeHealth(_amountHealth))
                {
                    _isUsed = true;
                    Debug.Log($"Player take {_amountHealth}HP");
                }
                else
                {
                    Debug.Log("здоровья полная");
                }
            }
            else if (_isDamageBoost)
            {
                if (_player != null)
                {
                    StartCoroutine(TryTakeDamage());
                    _isUsed = true;
                    Debug.Log($"Player take {_amountDamage}More Damage");
                }
                else
                {
                    Debug.Log("урон от пуль стал больше");
                }
            }
            else
            {
                Instantiate(_currentBoost, transform.position, Quaternion.identity);
                Debug.Log($"Boost {_currentBoost.name} used");
                _isUsed = true;
            }

            if (_isUsed)
            {
                _currentBoost = null;
                _currentBoostSprite = null;
                _hasBoost = false;
                _isBulletBoost = false;
                _isHealthBoost = false;
                _isDamageBoost = false;
                _boostImageUI.enabled = false;
            }
        }
    }
    private IEnumerator TryTakeDamage()
    {
        _player.IncreaseBulletDamage(_amountDamage);

        yield return new WaitForSeconds(_damageDirection);

        _player.IncreaseBulletDamage(-_amountDamage);
    }
}