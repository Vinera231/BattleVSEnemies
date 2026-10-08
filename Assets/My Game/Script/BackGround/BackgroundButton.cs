using UnityEngine;

public class BackgroundButton: MonoBehaviour
{
    [SerializeField] private ButtonInformer _informer;
    [SerializeField] private BackgroundPanel _panel;

    private void OnEnable()
    {
        _informer.Clicked += OnClick;
    }

    private void OnDisable()
    {
        _informer.Clicked -= OnClick;
    }

    private void OnClick()
    {
        _panel.Show();
    }
}