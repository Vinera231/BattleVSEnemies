using System;
using TMPro;
using UnityEngine;

public class WavePassed : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private WaveManager _waveManager;

    private void OnEnable() =>
        UpdateText();

    private void UpdateText() =>   
        _text.text = _waveManager.WavePassed.ToString();  
}