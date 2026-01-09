using UnityEngine;

public class CursorShower : MonoBehaviour
{
    [SerializeField] private bool _isShow;

    private int _counterToShow = 0;

    public static CursorShower Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);

            _counterToShow = _isShow ? 1 : 0;

            return;
        }

        Destroy(gameObject);
    }

    private void OnEnable() =>
        ProcessShow();

    private void ProcessShow()
    {
        if(_counterToShow > 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        Debug.Log($"CursorState = {_counterToShow > 0}, Cursor.visible = {Cursor.visible}, Cursor.lockState = {Cursor.lockState}");
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
}