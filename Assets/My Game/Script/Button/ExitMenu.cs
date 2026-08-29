using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
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
        SceneManager.LoadScene(0);
    }
}