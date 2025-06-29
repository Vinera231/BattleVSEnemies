using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    [SerializeField] private InputReader _reader;
    [SerializeField] private Player _player;

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

    public void OnExitToMenuPressed() =>
        LoadMenu();

    private void OnPlayrDied() =>
        LoadMenu();

    private void LoadMenu() =>
        SceneManager.LoadScene(0);
}