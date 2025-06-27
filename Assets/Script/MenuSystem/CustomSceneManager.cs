using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    [SerializeField] private InputReader _reader;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _reader.ExitToMenuPressed += OnExitToMenuPressed;

        if (_player != null)
            _player.Died += OnPlayrDied;
    }

    private void OnDisable()
    {
        _reader.ExitToMenuPressed -= OnExitToMenuPressed;

        if (_player != null)
            _player.Died -= OnPlayrDied;
    }

    private void OnExitToMenuPressed() =>
        LoadMenu();

    private void OnPlayrDied() =>
        LoadMenu();

    private void LoadMenu() =>
        SceneManager.LoadScene(0);
}