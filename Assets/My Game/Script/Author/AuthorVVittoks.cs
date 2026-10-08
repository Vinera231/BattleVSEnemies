using UnityEngine;
using UnityEngine.UI;

public class AuthorVVittoks : MonoBehaviour
{
    [SerializeField] private Button _vvittoks;

    private void OnEnable()
    {
        _vvittoks.onClick.AddListener(AuthorGroup);
    }

    private void OnDisable()
    {
        _vvittoks.onClick.RemoveListener(AuthorGroup);
    }

    private void AuthorGroup()
    {
        Application.OpenURL("https://t.me/VVittox");
    }
}