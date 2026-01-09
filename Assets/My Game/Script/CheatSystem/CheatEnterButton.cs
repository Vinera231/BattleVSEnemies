using System;
using UnityEngine;
using UnityEngine.UI;

public class CheatEnterButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    public event Action Clicked;

    private void OnEnable() =>
        _button.onClick.AddListener(OnClick);

    private void OnDisable() =>
        _button.onClick.RemoveListener(OnClick);

    private void OnClick() =>
        Clicked?.Invoke();
}