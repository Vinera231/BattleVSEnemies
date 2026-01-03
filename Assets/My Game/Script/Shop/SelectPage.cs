using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class SelectPage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textArrow;
    [SerializeField] private GameObject[] _categoria;
    [SerializeField] private InputReader _reader;
    [SerializeField] private TextMeshProUGUI _textSelect;
    [SerializeField] private Image _arrow;

    private int _currentIndex = 0;

    private void OnEnable()
    {
        _reader.SelectPressed += PressArrow;
        _reader.BackSelectPressed += PressArrow;
    }

    private void OnDisable()
    {
        _reader.SelectPressed -= PressArrow;
        _reader.BackSelectPressed -= PressArrow;
    }

    public void PressArrow()
    {
        _categoria[_currentIndex].SetActive(false);
        _currentIndex = (_currentIndex + 1) % _categoria.Length;

        _categoria[_currentIndex].SetActive(true);
        _textArrow.text = _categoria[_currentIndex].name;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _textSelect.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _textSelect.gameObject.SetActive(false);
        }
    }
}