using UnityEngine;
using UnityEngine.UI;

public class AuthorBratkevich : MonoBehaviour
{
    [SerializeField] private Button _bratkevich;

    private void OnEnable()
    {
        _bratkevich.onClick.AddListener(AuthorGroup);
    }

    private void OnDisable()
    {
        _bratkevich.onClick.RemoveListener(AuthorGroup);
    }

    private void AuthorGroup()
    {
        Application.OpenURL("https://t.me/myIgrova");
    }
}
