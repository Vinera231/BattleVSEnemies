using UnityEngine;
using UnityEngine.UI;

public class Iventar : MonoBehaviour
{
    [SerializeField] private InputReader _reader;
    [SerializeField] private Player _player;
    [SerializeField] private int _amountBullet;
    [SerializeField] private int _amountHealth;
    [SerializeField] private Image _boostImageUI;

    private Sprite _currentBoostSprite;
    private GameObject _currentBoost;
    private bool _hasBoost;
    private bool _isBulletBoost;
    private bool _isHealthBoost;

    private void OnEnable()
    {
        _reader.IventarPressed += UseBoost;
    }

    private void OnDisable()
    {
        _reader.IventarPressed -= UseBoost;
    }

    public bool PressIventar(GameObject currentboostPrefab, Sprite currentboostSprite, bool isBullet = false, bool isHealth = false)
    {
        if (_hasBoost)
            return false;

        _currentBoost = currentboostPrefab;
        _currentBoostSprite = currentboostSprite;
        _hasBoost = true;
        _isBulletBoost = isBullet;
        _isHealthBoost = isHealth;

        if (_currentBoostSprite != null)
        {
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
                    Debug.Log($"Player take {_amountBullet}");
                }
            }
            else
            {
                Instantiate(_currentBoostSprite, transform.position, Quaternion.identity);
                Debug.Log($"Boost {_currentBoost.name} used");
            }

            if (_isHealthBoost)
            {
                if(_player != null && _player.TryTakeHealth(_amountHealth)) 
                {
                    Debug.Log($"Player take {_amountHealth}");
                }
            }
            else
            {
                Instantiate(_currentBoostSprite, transform.position, Quaternion.identity);
                Debug.Log($"Boost {_currentBoost.name} used");
            }

            _currentBoost = null;
            _currentBoostSprite = null;
            _hasBoost = false;
            _isBulletBoost = false;
            _boostImageUI.enabled = false;
        }
    }
}