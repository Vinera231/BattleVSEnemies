using TMPro;
using UnityEngine;

public abstract class Shop : MonoBehaviour
{
    protected const KeyCode Key = KeyCode.Tab;

    [SerializeField] private int _price;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private InputReader _reader;
    [SerializeField] private Score _score;
    [SerializeField] private SfxPlayer _sfx;
    [SerializeField] private TextMeshProUGUI _helpText;
    [SerializeField] private bool _isConsumable = true;
    [SerializeField] private GameObject _signPrefad;

    protected Player Player;

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
            _signPrefad.SetActive(true);
            Player = player;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player _))
        {
            _text.gameObject.SetActive(false);
            _helpText.gameObject.SetActive(false);
            _signPrefad.SetActive(false);
            Player = null;
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
  
    protected void ResetPrice()
    {
        _price = 0;
        _text.text = _price.ToString();
    }
   
    private void OnBuyPressed()
    {
        if (Player != null && _score.TrySpendScore(_price))
        {
            if (TryApplyItem())
            {
                _sfx.PlayBuyItem();
            }

            if (_isConsumable)
                Destroy(gameObject);
        }
    }

    protected abstract bool TryApplyItem();
}