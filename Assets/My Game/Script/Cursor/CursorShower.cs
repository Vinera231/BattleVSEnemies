using UnityEngine;

public class CursorShower : MonoBehaviour
{
    private int _counterToShow = 0;

    public static CursorShower Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);

            return;
        }

        Destroy(gameObject);
    }

    private void OnEnable()
    {
        if (Instance == this)
            ProcessShow();
    }

    public void Show()
    {
        _counterToShow++;
        ProcessShow();
    }

    public void Hide()
    {
        _counterToShow--;
        ProcessShow();
    }

    private void ProcessShow()
    {
        if (_counterToShow > 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}