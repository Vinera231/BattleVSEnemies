using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _twoPhaseMusic;
    [SerializeField] private AudioClip _dabtStepMusic;
    [SerializeField] private AudioClip _bossMusic;
    [SerializeField] private Wave _beforeBoss;
    [SerializeField] private Wave _afterBoss;

    private void OnEnable()
    {
        _beforeBoss.Finished += PlayBossMusic;
        _afterBoss.Finished += PlayTwoPhaseMusic;
    }


    private void OnDisable()
    {
        _beforeBoss.Finished -= PlayBossMusic;
        _afterBoss.Finished -= PlayTwoPhaseMusic;
    }

    public void PlayBossMusic() =>
        Play(_bossMusic);

    public void PlayTwoPhaseMusic() =>
        Play(_twoPhaseMusic);

    public void PlayDadStepMusic() =>
        Play(_dabtStepMusic);

    private void Play(AudioClip clip)
    {
        _source.clip = clip;
        _source.Play();
    }
}