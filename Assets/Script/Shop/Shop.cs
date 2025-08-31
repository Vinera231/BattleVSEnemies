using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Shop : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private InputReader _reader;
    [SerializeField] private Score _score;
    [SerializeField] private SfxPlayer _sfx;
    [SerializeField] private TextMeshProUGUI _helpText;
    [SerializeField] private bool _isConsumable = true;

    protected Player _player;

    protected virtual void Awake()
    {
        _text.text = _price.ToString();
        _text.gameObject.SetActive(false);
    }

    protected virtual void OnEnable() =>
        _reader.BuyPressed += OnBuyPressed;

    protected virtual void OnDisable() =>
      _reader.BuyPressed -= OnBuyPressed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
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
        if (_player != null && _score.TrySpendScore(_price))
        {
            if (GiveItem())
                _sfx.PlayBuyIteam();

            if (_isConsumable)
                Destroy(gameObject);         
        }
    }

    protected abstract bool GiveItem();
}