using TMPro;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void UpdateBulletCount(float count, float max) =>
        _text.text = $" {count}";

}
