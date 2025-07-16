using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanelClose : MonoBehaviour
{
    [SerializeField] private Wave _lastWave;
    [SerializeField] private WinPanel _winPanel;
    [SerializeField] private float _timePanel;

    private void OnEnable()
    {
        _lastWave.Finished += ClosePanel;
    }

    private void OnDisable()
    {
        _lastWave.Finished -= ClosePanel;
    }

    public void ClosePanel()
    {
        if (_timePanel < 0)
        {
            _winPanel.gameObject.SetActive(false);
            SceneManager.LoadScene(0);
        }
    }
}