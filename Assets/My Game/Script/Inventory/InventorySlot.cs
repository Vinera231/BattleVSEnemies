using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _hotkey;
    [SerializeField] private GameObject _frame;
    
    private KeyCode _keyCode;
    private Action _onApply;

    public KeyCode Hotkey => _keyCode;

    public void Init(Sprite sprite, KeyCode keyCode, Action onApply)
    {
        _image.sprite = sprite;
        _keyCode = keyCode;
        _onApply = onApply;
        _hotkey.text = keyCode.ToString();
        Unselect();
    }

    public void Select() =>
        _frame.SetActive(true);

    public void Unselect() =>
        _frame.SetActive(false);

    public void Apply() =>
      _onApply?.Invoke(); 
}