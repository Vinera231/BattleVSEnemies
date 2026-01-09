using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
    private void OnEnable()
    {
        PauseSwitcher.Instance.PauseGame();
        CursorShower.Instance.Show();
    }
   
    private void OnDisable()
    {
        PauseSwitcher.Instance.PlayGame();
        CursorShower.Instance.Hide();
    }

    public void Show() =>
        gameObject.SetActive(true);

    public void Hide() =>
        gameObject.SetActive(false);
}