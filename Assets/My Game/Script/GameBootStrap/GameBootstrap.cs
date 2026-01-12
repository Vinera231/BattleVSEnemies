using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    private void OnEnable()
    {
        CursorShower.Instance.Hide();
    }

    private void OnDisable()
    {
        CursorShower.Instance.Show();
    }
}
