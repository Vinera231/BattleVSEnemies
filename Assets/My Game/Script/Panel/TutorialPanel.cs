using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
    [SerializeField] private PauseSwitcher _pauseSwitcher;

    private void OnEnable() =>
        _pauseSwitcher.PauseGame(gameObject);
   
    private void OnDisable() =>   
        _pauseSwitcher.PlayGame(gameObject);

    public void Show() =>
        gameObject.SetActive(true);

    public void Hide() =>
        gameObject.SetActive(false);
}
