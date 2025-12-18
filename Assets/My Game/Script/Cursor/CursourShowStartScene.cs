using UnityEngine;

public class CursourShowStartScene : MonoBehaviour
{
    private void Start()
    {
        Show();
    }

    public void Show()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}