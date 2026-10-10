using UnityEngine;
using UnityEngine.UI;

public class ThemeSwitcher : MonoBehaviour
{
    [SerializeField] private MenuBox[] _themes;
    [SerializeField] private Image _background;

    private void Awake()
    {
        ResetAllThemes();

        bool isUnlock = SaverSystem.isUnlocked(2);    
        _themes[2].SetLock(isUnlock == false);

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

    private void OnThemeClicked(MenuBox box)
    {
        if (box.IsLocked)
            return;

        ResetAllThemes();
        box.SetSelect(true);
        _background.sprite = box.Sprite;

        int index = System.Array.IndexOf(_themes, box);

        if (index >= 0)
            SaverSystem.Select(index);
    }

    private void ResetAllThemes()
    {
        foreach (var theme in _themes)
        {
            theme.SetSelect(false);
        }
    }

    public void RefreshThemes()
    {
        for (int i = 0; i < _themes.Length; i++)
        {
            bool isUnclock = SaverSystem.isUnlocked(i);
            _themes[i].SetLock(isUnclock == true);
            _themes[2].SetLock(true);
        }
    }
}
