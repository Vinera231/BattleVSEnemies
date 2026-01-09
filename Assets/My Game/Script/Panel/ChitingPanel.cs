using UnityEngine;

public class ChitingPanel : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
        CursorShower.Instance.Show();
        PauseSwitcher.Instance.PauseGame();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        CursorShower.Instance.Hide();
        PauseSwitcher.Instance.PlayGame();
    }
}