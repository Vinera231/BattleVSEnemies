using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private const string TextFirstWave = " First Wave";
    private const string TextSecondWave = " Second Wave";
    private const string TextThirdWave = " Third Wave";
    private const string TextForthWave = " Forth Wave";
    private const string TextFifthWave = " Fifth Wave";

    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private WinPanel _winPanel;

    private float _waveStartTime;
    private bool _isActiveWave;

    private void Start() =>
        StartWave(0, TextFirstWave, OnFirstWaveFinished);
    

    private void Update()
    {
        if (_isActiveWave == false)
            return;

        float elapsed = Time.time - _waveStartTime;
        _timeText.text = $"Wave: {elapsed:F1} ";
    }

    private void StartWave(int index, string labelText, System.Action onFinished)
    {
        _waveStartTime = Time.time;
        _isActiveWave = true;
        _waves[index].StartSpawn();
        _waves[index].Finished += onFinished;
        _text.text = labelText;
    }
    private void OnFirstWaveFinished()
    {
        _waves[0].Finished -= OnFirstWaveFinished;
        _isActiveWave = false;

        StartWave(1, TextSecondWave, OnSecondWaveFinished);
    }

    private void OnSecondWaveFinished()
    {
        _waves[1].Finished -= OnSecondWaveFinished;
        _isActiveWave = false;

        StartWave(2, TextThirdWave, OnThirdWaveFinished);
    }

    private void OnThirdWaveFinished()
    {
        _waves[2].Finished -= OnThirdWaveFinished;
        _isActiveWave = false;

        StartWave(3, TextForthWave, OnForthWaveFinished);
    }

    private void OnForthWaveFinished()
    {
        _waves[3].Finished -= OnForthWaveFinished;
        _isActiveWave = false;

        StartWave(4, TextFifthWave, OnFifthWaveFinished);
    }

    private void OnFifthWaveFinished()
    {
        _waves[4].Finished -= OnForthWaveFinished;
        _isActiveWave = false;
    }
}