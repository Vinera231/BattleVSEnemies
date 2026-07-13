using TMPro;
using UnityEngine;

public class WaveTotalTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Update() =>
        TotalTime();   

    public void TotalTime()
    {
        float time = Time.time;
      _text.text = $"{time:F1}"; 
    }   
}