using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private SfxPlayer _sfx;
    [SerializeField] private ButtonInformer _informer;

    private void OnEnable()
    {
        _informer.Entered += OnEnter;
        _informer.Exited += OnExit;
        _informer.Clicked += OnClick;
    }

    private void OnDisable()
    {
        _informer.Entered -= OnEnter;
        _informer.Exited -= OnExit;
        _informer.Clicked -= OnClick;
    }

    private void OnEnter() =>
        _sfx.PlayCursorEnterButton();

    private void OnExit() =>
        _sfx.PlayCursorExitButton();

    private void OnClick() =>
        _sfx.PlayClickButton();
}