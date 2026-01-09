using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private ButtonInformer _informer;

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