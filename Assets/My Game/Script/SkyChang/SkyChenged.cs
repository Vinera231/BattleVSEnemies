using Microsoft.Unity.VisualStudio.Editor;
using NUnit.Framework.Interfaces;
using UnityEngine;

public class SkyChenged : MonoBehaviour
{
    [SerializeField] private Material _normalSky;
    [SerializeField] private Material _darkSky;

    [Header("Wave Setting")]
    [SerializeField] private int _changWave = 11;

    private bool _isChenged;

    public void OnWaveChanged(int currentWave)
    {
        if (_isChenged)
            return;

        if(currentWave == _changWave)
        {
            RenderSettings.skybox = _darkSky;
            DynamicGI.UpdateEnvironment();
            _isChenged = true;
        }
    }
}
