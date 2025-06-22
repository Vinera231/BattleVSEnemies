using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void ShowInfo(float value, float maxValue)
    {
        _image.fillAmount = value / maxValue;
    }

}