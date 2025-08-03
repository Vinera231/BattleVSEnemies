using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _price;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private InputReader _reader;
    [SerializeField] private Score _score;
    [SerializeField] private SfxPlayer _sfx;
    [SerializeField] private TextMeshProUGUI _helpText;

    private Player _player;

    private void Awake()
    {
        _text.text = _price.ToString();
        _text.gameObject.SetActive(false);
    }

    private void OnEnable() =>
        _reader.BuyPressed += OnBuyPressed;

    private void OnDisable() =>
      _reader.BuyPressed -= OnBuyPressed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            _text.gameObject.SetActive(true);
            _helpText.gameObject.SetActive(true);
            _player = player;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player _))
        {
            _text.gameObject.SetActive(false);
            _helpText.gameObject.SetActive(false);
            _player = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Player _))
        {
            if (_score.Value >= _price)
                _text.color = Color.green;
            else
                _text.color = Color.red;
        }
    }

    private void OnBuyPressed()
    {
        if(_player != null)
        {
            if(_score.TrySpendScore(_price))
            {
                Destroy(gameObject);
                _bulletSpawner.ReplacePrefab(_bulletPrefab);
                _sfx.PlayBuyBullet();
            }
        }
    }

}