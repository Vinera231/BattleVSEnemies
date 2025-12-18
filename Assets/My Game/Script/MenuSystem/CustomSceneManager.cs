using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    [SerializeField] private InputReader _reader;
    [SerializeField] private Player _player;

    public Action OnDieded;

    private void OnEnable()
    {
        if (_player != null)
            _player.Died += OnPlayrDied;
    }

    private void OnDisable()
    {
        if (_player != null)
            _player.Died -= OnPlayrDied;
    }
   
    private void OnPlayrDied() =>
        LoadMenu();

    private void LoadMenu() =>
        SceneManager.LoadScene(0);
}