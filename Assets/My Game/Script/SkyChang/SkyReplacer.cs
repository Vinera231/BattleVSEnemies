using System;
using System.Collections.Generic;
using UnityEngine;

public class SkyReplacer : MonoBehaviour
{
    [SerializeField] private WaveManager _waveManager;
    [SerializeField] private List<SkyInfo> _infos;
    [SerializeField] private Light _night;
    [SerializeField] private GameObject _rain;

    private void OnEnable() =>    
        _waveManager.WaveStarted += OnWaveChanged;
    
    private void OnDisable() =>   
        _waveManager.WaveStarted -= OnWaveChanged;
    
    private void OnWaveChanged(int waveIndex)
    {
        foreach (SkyInfo info in _infos)
        {
            if (waveIndex == info.WaveIndex)
            {
                RenderSettings.skybox = info.Sky;
                return;
            }
        }

        if (_waveManager.CurrentWaveIndex == 10)
            _night.color = Color.black;

        if (_waveManager.CurrentWaveIndex == 18)
        {
            _rain.SetActive(true);
            SfxPlayer.Instance.PlayRainSound();
        }
    }
}

[Serializable]
public class SkyInfo
{
    [SerializeField] private Material _sky;
    [SerializeField] private int _waveIndex;

    public Material Sky => _sky;

    public int WaveIndex => _waveIndex;
}