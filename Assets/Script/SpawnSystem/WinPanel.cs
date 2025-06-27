using UnityEngine;

public class WinPanel : MonoBehaviour 
{
    public void Show() =>
        gameObject.SetActive(true);

    public void Hide() =>
        gameObject.SetActive(false);
}
