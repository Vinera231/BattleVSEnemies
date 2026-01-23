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

    public void OnPlayrDied() =>
        LoadMenu();

    public void LoadMenu() =>
        SceneManager.LoadScene(0);

    public void LoadEasyMod() =>
        SceneManager.LoadScene(2);

    public void LoadNormalMod() =>
           SceneManager.LoadScene(1);
}