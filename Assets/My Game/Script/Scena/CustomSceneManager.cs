using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    [SerializeField] private InputReader _reader;
    [SerializeField] private PlayerTakeDamage _player;

    public Action OnDieded;

    private void OnEnable()
    {
        if (_player != null)
            _player.PlayerDied += OnPlayrDied;
    }

    private void OnDisable()
    {
        if (_player != null)
            _player.PlayerDied -= OnPlayrDied;
    }

    public void OnPlayrDied() =>
        LoadMenu();

    public void LoadMenu() =>
        SceneManager.LoadScene(0);

    public void LoadNormalMode()
    {
        SceneManager.LoadScene(1);
        CursorShower.Instance.Hide();
    }

    public void LoadEasyMode()
    {
        SceneManager.LoadScene(2);
        CursorShower.Instance.Hide();
    }

    public void LoadHardMode()
    {
        SceneManager.LoadScene(3);
        CursorShower.Instance.Hide();
    }
}