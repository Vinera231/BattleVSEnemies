using System;
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
    [SerializeField] private QuietPlace _quietPlace;

    private int _currentIndex = 0;
    private bool _isShock;

    private void OnEnable()
    {
        _reader.SelectPressed += PressArrow;
        _reader.BackSelectPressed += PressArrow;
        _quietPlace.PlayerEntered += OnPlayerEntered;
        _quietPlace.PlayerExited += OnPlayerExited;
    }
    
    private void OnDisable()
    {
        _reader.SelectPressed -= PressArrow;
        _reader.BackSelectPressed -= PressArrow;
        _quietPlace.PlayerEntered-= OnPlayerEntered;
        _quietPlace.PlayerExited -= OnPlayerExited;
    }
   
    public void PressArrow()
    {
        if (_isShock == false)
            return;

        _categoria[_currentIndex].SetActive(false);
        _currentIndex = (_currentIndex + 1) % _categoria.Length;

        _categoria[_currentIndex].SetActive(true);
        _textArrow.text = _categoria[_currentIndex].name;
    }

    private void OnPlayerEntered()
    {
        _textSelect.gameObject.SetActive(true);
        _isShock = true;
    }
    private void OnPlayerExited()
    {
        _textSelect.gameObject.SetActive(false);
        _isShock = false;
    }

    
}