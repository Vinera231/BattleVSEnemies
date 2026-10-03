using UnityEngine;
using UnityEngine.UI;

public class ThemeSwitcher : MonoBehaviour
{
    [SerializeField] private MenuBox[] _themes;
    [SerializeField] private Image _background;

    private void Awake()
    {
        ResetAllThemes();
        _themes[0].SetLock(false);
        _themes[0].SetSelect(true);
        _background.sprite = _themes[0].Sprite;
    }

    private void OnEnable()
    {
        foreach (var theme in _themes)
        {
            theme.Clicked += OnThemeClicked;
        }
    }

    private void OnDisable()
    {
        foreach (var theme in _themes)
        {
            theme.Clicked -= OnThemeClicked;
        }
    }

    public void Unlock(int index)
    {
        _themes[index].SetLock(false);
    }

    private void OnThemeClicked(MenuBox box)
    {
        if (box.IsLocked)
            return;
        Debug.Log(nameof(OnThemeClicked));

        ResetAllThemes();
        box.SetSelect(true);
        _background.sprite = box.Sprite;
    }

    private void ResetAllThemes()
    {
        foreach (var theme in _themes)
        {
            theme.SetSelect(false);
        }
    }
}