using UnityEngine;
using UnityEngine.SceneManagement;

public class HotKeyEscape : MonoBehaviour
{
    private void Update()
    {
        ExitToMenu();
    }

    private void ExitToMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

 } 
