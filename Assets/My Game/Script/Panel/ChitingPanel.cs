using UnityEngine;

public class ChitingPanel : MonoBehaviour
{
    private void OnEnable()
    {
        CursorShower.Instance.Show();
        PauseSwitcher.Instance.PauseGame();
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