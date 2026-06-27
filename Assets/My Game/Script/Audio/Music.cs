using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _twoPhaseMusic;
    [SerializeField] private AudioClip _dabtStepMusic;
    [SerializeField] private AudioClip _bossMusic;
    [SerializeField] private AudioClip _finalSoundMusic;
    [SerializeField] private Wave _beforeBoss;
    [SerializeField] private Wave _afterBoss;
    [SerializeField] private Wave _beforeFinal;

    private void OnEnable()
    {
        _beforeBoss.Finished += PlayBossMusic;
        _afterBoss.Finished += PlayTwoPhaseMusic;
        _beforeFinal.Finished += PlayFinalMusic;
    }

    private void OnDisable()
    {
        _beforeBoss.Finished -= PlayBossMusic;
        _afterBoss.Finished -= PlayTwoPhaseMusic;
        _beforeFinal.Finished -= PlayFinalMusic;
    }

    public void PlayBossMusic() =>
        Play(_bossMusic);
    public void PlayFinalMusic() =>
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