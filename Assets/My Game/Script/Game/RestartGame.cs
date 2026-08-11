using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private ButtonInformer _informer;
  
    private void OnEnable()
    {
        _informer.Clicked += ResetGame;
    }

    private void OnDisable()
    {
        _informer.Clicked -= ResetGame;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}