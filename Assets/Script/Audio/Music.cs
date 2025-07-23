using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _defaultMusic;
    [SerializeField] private AudioClip _bossMusic;
    [SerializeField] private Wave _beforeBoss;

    private void OnEnable() =>
        _beforeBoss.Finished += PlayBossMusic;

    private void OnDisable() =>
        _beforeBoss.Finished -= PlayBossMusic;

    public void PlayBossMusic() =>
        Play(_bossMusic);

    public void PlayDefaultMusic() =>
        Play(_defaultMusic);

    private void Play(AudioClip clip)
    {
        _source.clip = clip;
        _source.Play();
    }
}