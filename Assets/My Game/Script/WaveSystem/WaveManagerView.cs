using TMPro;
using UnityEngine;

public class WaveManagerView : MonoBehaviour
{
    [SerializeField] private WaveManager _waveManager;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _time;
   
    private float _waveStartTime;
   
    private void Update()
    {
        if (_waveManager.IsActiveWave == false)
            return;

        float elapsed = Time.time - _waveStartTime;
        _time.text = $"Time: {elapsed:F1}";
    }
  
    private void OnEnable()
    {
        OnStartWave(_waveManager.CurrentWaveIndex);
        _waveManager.WaveStarted += OnStartWave;
    }
  
    private void OnDisable() =>  
        _waveManager.WaveStarted -= OnStartWave;  
    
    private void OnStartWave(int index)
    {
        _name.text = _waveManager.GetWaveName(index); 
        _waveStartTime = Time.time;
    }    
}