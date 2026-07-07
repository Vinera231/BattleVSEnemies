using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    [SerializeField] private InputReader _reader;

    public void LoadMenu() =>
        SceneManager.LoadScene(0);

    public void LoadNormalMode()
    {
        SceneManager.LoadScene(1);  
    }

    public void LoadEasyMode()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadHardMode()
    {
        SceneManager.LoadScene(3);
    }
}