using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] _hideIcon;

    private int _currentIndex = 0;
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

    public void Show()
    {
        gameObject.SetActive(true);

        foreach(var icon in _hideIcon)      
            icon.SetActive(false);
        
        if ( _currentIndex < _hideIcon.Length)
       _hideIcon[_currentIndex].SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);

        foreach (var icon in _hideIcon)
            icon.SetActive(true);
    }
}