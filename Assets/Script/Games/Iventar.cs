using UnityEngine;
using UnityEngine.UI;

public class Iventar : MonoBehaviour
{
    [SerializeField] private InputReader _reader;
    [SerializeField] private Image _boostImageUI;
    [SerializeField] private Player _player;
    [SerializeField] private int _amountBullet;

    private Sprite _currentBoostSprite;
    private GameObject _currentBoost;
    private bool _hasBoost;
    private bool _isBulletBoost;

    private void OnEnable()
    {
        _reader.IventarPressed += UseBoost;
    }

    private void OnDisable()
    {
        _reader.IventarPressed -= UseBoost;
    }

    public bool PressIventar(GameObject currentboostPrefab, Sprite currentboostSprite, bool isBullet = false)
    {
        if (_hasBoost)
            return false;

        _currentBoost = currentboostPrefab;
        _currentBoostSprite = currentboostSprite;
        _hasBoost = true;
        _isBulletBoost = isBullet;

        if (_currentBoostSprite != null)
        {
            _boostImageUI.enabled = _currentBoostSprite;
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

            _currentBoost = null;
            _currentBoostSprite = null;
            _hasBoost = false;
            _isBulletBoost = false;
            _boostImageUI.enabled = false;

        }
    }
}