using UnityEngine;

public class GameEfect : MonoBehaviour
{
    [SerializeField] AudioSource _source;
    [SerializeField] private AudioClip _notBullet;
    [SerializeField] private AudioClip _reloadBullet;   

    public void PlayNotBullet() =>
     _source.PlayOneShot(_notBullet);

    public void PlayReloadBullet() =>
     _source.PlayOneShot(_reloadBullet);

}
