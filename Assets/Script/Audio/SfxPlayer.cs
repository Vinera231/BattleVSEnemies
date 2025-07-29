using UnityEngine;

public class SfxPlayer : MonoBehaviour
{
    public static SfxPlayer Instance { get; private set; }

    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _cursourEnterButton;
    [SerializeField] private AudioClip _cursorExitButton;
    [SerializeField] private AudioClip _clickButton;
    [SerializeField] private AudioClip _notBullet;
    [SerializeField] private AudioClip _reloadBullet;
    [SerializeField] private AudioClip _kickEnemy;
    [SerializeField] private AudioClip _hammerEnemy;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void PlayCursorEnterButton() =>
        _source.PlayOneShot(_cursourEnterButton);

    public void PlayCursorExitButton()
    {
        // Добавишь, если нужен будет звук выхода курсора с кнопки
        // _source.PlayOneShot(_cursorExitButton);
    }

    public void PlayClickButton() =>
        _source.PlayOneShot(_clickButton);

    public void PlayNotBullet() =>
        _source.PlayOneShot(_notBullet);

    public void PlayReloadBullet() =>
        _source.PlayOneShot(_reloadBullet);

    public void PlayKickEnemy() =>
       _source.PlayOneShot(_kickEnemy);

    public void PlayKickHammerEnemy() =>
       _source.PlayOneShot(_hammerEnemy);
}