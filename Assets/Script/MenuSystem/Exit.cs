using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private ButtonInformer _informer;

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
        Application.Quit();
    }
}