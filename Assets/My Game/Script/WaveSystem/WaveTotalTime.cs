using TMPro;
using UnityEngine;

public class WaveTotalTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private WaveManagerView _view;

    private void OnEnable() =>
       TotalTime();

    private void Update() =>
        TotalTime();   

    public void TotalTime()
    {
        float time = Time.time;
        _text.text = _view.TotalTime.ToString();
    }   
}