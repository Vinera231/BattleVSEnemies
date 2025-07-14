using UnityEngine;

public class Sight: MonoBehaviour
{
    [SerializeField] private GameObject _sight;
    [SerializeField] private CursorShower _cursorShower;

    private void Start()
    {
        ShowSight();
    }

    private void OnEnable()
    {
        _cursorShower.OnCursourShow += HideSight;
        _cursorShower.OnCursourHide += ShowSight;

    }

    private void OnDisable()
    {
        _cursorShower.OnCursourShow -= HideSight;
        _cursorShower.OnCursourHide -= ShowSight;

    }

    public void ShowSight()
    {
        _sight.SetActive(true);
    }
    
    public void HideSight()
    {
        _sight.SetActive(false);
    }
}