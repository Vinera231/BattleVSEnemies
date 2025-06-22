using UnityEngine;

public class ButtonClosePanel : MonoBehaviour
{
    [SerializeField] private ButtonInformer _informer;
    [SerializeField] private GameObject Panel;

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
        Panel.SetActive(false);
    }
}