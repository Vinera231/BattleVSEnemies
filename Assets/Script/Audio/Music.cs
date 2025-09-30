using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _defaultMusic;
    [SerializeField] private AudioClip _bossMusic;
    [SerializeField] private Wave _beforeBoss;
    [SerializeField] private Wave _afterBoss;

    private void OnEnable()
    {
     _beforeBoss.Finished += PlayBossMusic;
     _afterBoss.Finished += PlayDefaultMusic;
    }
        

    private void OnDisable()
    {
     _beforeBoss.Finished -= PlayBossMusic;
     _afterBoss.Finished -= PlayDefaultMusic;
    }        

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