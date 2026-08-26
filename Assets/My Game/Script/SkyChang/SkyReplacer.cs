using System;
using System.Collections.Generic;
using UnityEngine;

public class SkyReplacer : MonoBehaviour
{
    [SerializeField] private WaveManager _waveManager;
    [SerializeField] private List<SkyInfo> _infos;
    [SerializeField] private Light _light;
    [SerializeField] private ParticleSystem _rain;

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
                break;
            }
        }

        if (_waveManager.CurrentWaveIndex == 10)
            _light.color = Color.black;

        if (_waveManager.CurrentWaveIndex == 18)
        {
            SfxPlayer.Instance.PlayRainSound();
            _rain.gameObject.SetActive(true);
            _rain.Play();
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