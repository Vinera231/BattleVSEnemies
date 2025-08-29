using TMPro;
using UnityEngine;

public class SelectPage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textArrow;
    [SerializeField] private GameObject[] _categoria;
    [SerializeField] private InputReader _reader;
    [SerializeField] private TextMeshProUGUI _textSelect;

    private int _currentIndex = 0;

    private void OnEnable()
    {
        _reader.SelectPressed += PressArrow;
    }

    private void OnDisable()
    {
        _reader.SelectPressed -= PressArrow;
    }

    public void PressArrow()
    {
        _categoria[_currentIndex].SetActive(true);
        _currentIndex = (_currentIndex + 1) % _categoria.Length;
        _categoria[_currentIndex].SetActive(false);
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