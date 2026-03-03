using UnityEngine;

public class SfxPlayer : MonoBehaviour
{
    public static SfxPlayer Instance { get; private set; }

    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioSource _sourceSaw;
    [SerializeField] private AudioClip _cursourEnterButton;
    [SerializeField] private AudioClip _cursorExitButton;
    [SerializeField] private AudioClip _clickButton;
    [SerializeField] private AudioClip _notBullet;
    [SerializeField] private AudioClip _reloadBullet;
    [SerializeField] private AudioClip _kickEnemy;
    [SerializeField] private AudioClip _hammerEnemy;
    [SerializeField] private AudioClip _recoverPlayer;
    [SerializeField] private AudioClip _buyBullet;
    [SerializeField] private AudioClip _frostSound;
    [SerializeField] private AudioClip _frostShootSound;
    [SerializeField] private AudioClip _fireSound;
    [SerializeField] private AudioClip _fireShootSound;
    [SerializeField] private AudioClip _gunSound;
    [SerializeField] private AudioClip _explorelSound;
    [SerializeField] private AudioClip _poisonShootSound;
    [SerializeField] private AudioClip _laserSound;
    [SerializeField] private AudioClip _knifeSound;
    [SerializeField] private AudioClip _axeSound;
    [SerializeField] private AudioClip _sawSound;
    [SerializeField] private AudioClip _detonationSound;
    [SerializeField] private AudioClip _enemyDied;
    [SerializeField] private AudioClip _ahh;
    [SerializeField] private AudioClip _playerDied;
    [SerializeField] private AudioClip _bossDied;
    [SerializeField] private AudioClip _poisonSound;
    [SerializeField] private AudioClip _settingSound;
    [SerializeField] private AudioClip _speedSound;

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

    public void PlayHammerEnemy() =>
       _source.PlayOneShot(_hammerEnemy);

    public void PlayRecoverPlayer() =>
        _source.PlayOneShot(_recoverPlayer);

    public void PlayBuyItem() =>
        _source.PlayOneShot(_buyBullet);

    public void PlayFrostSound() =>
        _source.PlayOneShot(_frostSound);
    
    public void PlayFrostShootSound() =>
        _source.PlayOneShot(_frostShootSound);

    public void PlayFireSound() =>
        _source.PlayOneShot(_fireSound);
   
    public void PlayFireShootSound() =>
        _source.PlayOneShot(_fireShootSound);

    public void PlayExplorelSound() =>
        _source.PlayOneShot(_explorelSound);
   
    public void PlayDetonatorSound() =>
        _source.PlayOneShot(_detonationSound);

    public void PlayShootSound() =>
        _source.PlayOneShot(_gunSound);
  
    public void PlayLaserSound() =>
        _source.PlayOneShot(_laserSound);

    public void PlayKnifeSound() =>
        _source.PlayOneShot(_knifeSound);

    public void PlayAxeSound() =>
        _source.PlayOneShot(_axeSound);

    public void PlayChainsawSound()
    {
        if (_sourceSaw.isPlaying == false)
            _sourceSaw.Play();
    }

    public void StopChainsawSound() =>
        _sourceSaw.Stop();

    public void PlayDieEnemySound() =>
      _source.PlayOneShot(_enemyDied);

    public void PlayAhhSound() =>
      _source.PlayOneShot(_ahh);

    public void PlayDiePlayerSound() =>
      _source.PlayOneShot(_playerDied);

    public void PlayDieBossSound() =>
     _source.PlayOneShot(_bossDied);

    public void PlayPoisonSound() =>
   _source.PlayOneShot(_poisonSound);
  
    public void PlayShootPoisonSound() =>
   _source.PlayOneShot(_poisonShootSound);

    public void PlaySettingSound() =>
   _source.PlayOneShot(_settingSound);
  
    public void PlaySpeedSound() =>
   _source.PlayOneShot(_speedSound);
}