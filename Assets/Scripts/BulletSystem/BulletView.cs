using TMPro;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject[] _bulletUI;

    private const float FirstThreshold = 66f;
    private const float SecondThreshold = 33f;

    public void UpdateBulletCount(float count, float max)
    {
        _text.text = $"{count:F0}";

        if (_bulletUI.Length > 0)
            _bulletUI[0].SetActive(count >= FirstThreshold);

        if (_bulletUI.Length > 1)
            _bulletUI[1].SetActive(count >= SecondThreshold);
    }
}
