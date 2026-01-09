using System;
using UnityEngine;

public class ChitingPanelShower : MonoBehaviour
{
    [SerializeField] private ChitingPanel _panel;
    [SerializeField] private ButtonInformer _closeButton;
    [SerializeField] private InputReader _reader;
    
    private bool _isActive;

    public event Action<bool> Changed;

    private void OnEnable()
    {
        _reader.ChitingPanelPressed += OnPanelOpened;
        _closeButton.Clicked += PanelOff;
    }

    private void OnDisable()
    {
        _reader.ChitingPanelPressed -= OnPanelOpened;
        _closeButton.Clicked -= PanelOff;
    }

    private void PanelOff()
    {
        if (_panel.gameObject.activeSelf == false)
            return;

        _panel.Hide();        
    }

    private void PanelShow()
    {
        if (_panel.gameObject.activeSelf)
            return;

        _panel.Show();
    }

    private void OnPanelOpened()
    {
        _isActive = !_isActive;

        if (_isActive)
            PanelShow();
        else
            PanelOff();

        Changed?.Invoke(_isActive);
    }
}