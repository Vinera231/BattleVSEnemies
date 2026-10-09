using UnityEngine;
using UnityEngine.UI;

public class ThemeSwitcher : MonoBehaviour
{
    [SerializeField] private MenuBox[] _themes;
    [SerializeField] private Image _background;

    private void Awake()
    {
        ResetAllThemes();

        for (int i = 0; i < _themes.Length; i++)
        {
            bool isUnlock = SaverSystem.isUnlocked(i);
            _themes[i].SetLock(isUnlock == false);
        }

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
        if (index < 0 || index >= _themes.Length)
            return;
        _themes[index].SetLock(false);
        SaverSystem.Unlock(index);
    }

    private void OnThemeClicked(MenuBox box)
    {
        if (box.IsLocked)
            return;

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
