using UnityEngine;
using UnityEngine.UI;

public class VolumeIndicator : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private VolumeIndicatorInfo[] _infos;

    private void OnEnable()
    {
        _volumeSlider.onValueChanged.AddListener(OnChanged);
        OnChanged(_volumeSlider.value);
    }

    private void OnDisable()
    {
        _volumeSlider.onValueChanged.RemoveListener(OnChanged);
    }

    private void OnChanged(float value)
    {
        for (int i = _infos.Length - 1; i >= 0; i--)
        {
            if (value >= _infos[i].LowerThreshold)
            {
                _icon.sprite = _infos[i].Sprite;
                return;
            }
        }
    }
}
