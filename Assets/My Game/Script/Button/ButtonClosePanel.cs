using System;
using UnityEngine;

public class ButtonClosePanel : MonoBehaviour
{
    [SerializeField] private ButtonInformer _informer;

    public event Action PanelClosed;
   
    private void OnEnable() =>
        _informer.Clicked += OnClick;

    private void OnDisable() =>
        _informer.Clicked -= OnClick;

    public void OnClick()
    {
        PanelClosed?.Invoke();
    }
}