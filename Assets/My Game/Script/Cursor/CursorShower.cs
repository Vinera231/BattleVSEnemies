using UnityEngine;

public class CursorShower : MonoBehaviour
{
    private bool _isOn;

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

        if (_isOn)
            Show();
        else
            Hide();      
    }
  
    public void Show()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Hide()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
        //string cursor = _countCursour > 0 ? "Show" : "Hide";
        //Debug.Log($"CounterToShower = ({_countCursour},{cursor}");
}