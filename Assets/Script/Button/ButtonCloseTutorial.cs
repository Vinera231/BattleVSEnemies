using System;
using UnityEngine;

public class ButtonCloseTutorial : MonoBehaviour
{
    [SerializeField] private ButtonInformer _informer;
    [SerializeField] private GameObject _panel;

    public event Action ClosePanel;

    private void OnEnable()
    {
        _informer.Clicked += OnClick;
    }

    private void OnDisable()
    {
        _informer.Clicked -= OnClick;
    }

    public void OnClick()
    {
        Debug.Log("Click");
        _panel.SetActive(false);
        ClosePanel?.Invoke();
    }

}
