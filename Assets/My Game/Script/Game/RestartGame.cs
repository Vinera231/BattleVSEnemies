using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private ButtonInformer _informer;
  
    private void OnEnable()
    {
        CursorShower.Instance.Show();
        _informer.Clicked += ResetGame;
    }

    private void OnDisable()
    {
        CursorShower.Instance.Hide();
        _informer.Clicked -= ResetGame;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}