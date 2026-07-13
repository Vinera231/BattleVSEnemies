using System;
using TMPro;
using UnityEngine;

public class WavePassed : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private int _wavePassed;

    private void Update() => 
        UpdateText();
    public void CountWave()
    {
        _wavePassed++;
        UpdateText();
    }
  
    private void UpdateText() =>   
        _text.text = _wavePassed.ToString();    
}