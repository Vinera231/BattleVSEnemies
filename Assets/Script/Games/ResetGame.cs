using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    [SerializeField] ButtonInformer _informer;

    private void OnEnable()
    {
        _informer.Clicked += Reset;
    }

    private void OnDisable()
    {
        _informer.Clicked -= Reset;
    }

    private void Reset()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}