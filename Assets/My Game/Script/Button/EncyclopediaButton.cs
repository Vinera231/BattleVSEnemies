using UnityEngine;

public class EncyclopediaButton : MonoBehaviour
{
    [SerializeField] private ButtonInformer _informer;
    [SerializeField] private EncyclopediaPanel _panel;

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
