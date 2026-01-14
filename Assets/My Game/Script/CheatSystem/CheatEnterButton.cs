using System;
using UnityEngine;
using UnityEngine.UI;

public class CheatEnterButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private InputReader _reader;

    public event Action Clicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
        _reader.EnterCheatPanelPressed += OnClick;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
        _reader.EnterCheatPanelPressed -= OnClick;
    }

    private void OnClick() =>
        Clicked?.Invoke();
}