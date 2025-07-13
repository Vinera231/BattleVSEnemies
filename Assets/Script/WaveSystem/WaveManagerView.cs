using TMPro;
using UnityEngine;

public class WaveManagerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _time;

    public void SetName(string text) =>
        _name.text = text;

    public void SetTime(float elapsed) =>
        _time.text = $"Time: {elapsed:F1}";
}