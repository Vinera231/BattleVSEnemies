using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuBox : MonoBehaviour
{
    [SerializeField] private Image _selectBackground;
    [SerializeField] private GameObject _lockObject;
    [SerializeField] private Button _button;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private bool _isLock;

    public bool IsLocked => _isLock;
    public Sprite Sprite  => _sprite;

    public event Action<MenuBox> Clicked;

    private void Awake()
    {
        _lockObject.SetActive(_isLock);
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    public void SetSelect(bool selected)
    {
        _selectBackground.gameObject.SetActive(selected);
    }

    public void SetLock(bool locked)
    {
        _isLock = locked;
        _lockObject.SetActive(locked);
    }
    
    private void OnClick()
    {
        Clicked?.Invoke(this);
    }
}
