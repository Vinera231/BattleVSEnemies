using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class EnemyKilledView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private WaveManager _waveManager;

    private void OnEnable() =>  
        UpdateInfo();

    private void UpdateInfo() =>
        _text.text = _waveManager.EnemyKilled.ToString();    
}
