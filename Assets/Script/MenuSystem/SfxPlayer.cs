using UnityEngine;

public class SfxPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _cursorEnterButton;
    [SerializeField] private AudioClip _cursorExitButton;
    [SerializeField] private AudioClip _clickButton;

    public void PlayCursorEnterButton()
    {
        _source.PlayOneShot(_cursorEnterButton);
    }

    public void PlayCursorExitButton()
    {
    //    _source.PlayOneShot(_cursorExitButton);
    }

    public void PlayClickButton()
    {
        _source.PlayOneShot(_clickButton);
    }
}