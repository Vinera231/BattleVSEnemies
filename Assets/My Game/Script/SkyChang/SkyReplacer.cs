using System;
using System.Collections.Generic;
using UnityEngine;

public class SkyReplacer : MonoBehaviour
{
    [SerializeField] private WaveManager _waveManager;
    [SerializeField] private List<SkyInfo> _infos;

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