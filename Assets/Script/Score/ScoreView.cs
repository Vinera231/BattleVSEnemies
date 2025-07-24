using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    private const string Score = nameof(Score);

    [SerializeField] private TextMeshProUGUI _text;

    public void UpdateInfo(int score) =>
         _text.text = $"{Score}: {score}";
}