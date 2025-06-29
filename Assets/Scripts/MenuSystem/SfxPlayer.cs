using UnityEngine;

public class SfxPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _cursourEnterButton;
    [SerializeField] private AudioClip _cursorExitButton;
    [SerializeField] private AudioClip _clickButton;

    public void PlayCursorEnterButton() =>
        _source.PlayOneShot(_cursourEnterButton);

    public void PlayCursorExitButton()
    {
        // Добавишь, если нужен будет звук выхода курсора с кнопки
        // _source.PlayOneShot(_cursorExitButton);
    }

    public void PlayClickButton() =>
        _source.PlayOneShot(_clickButton);
}