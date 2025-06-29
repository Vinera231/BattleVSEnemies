using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;

    private void OnEnable() =>
         _volumeSlider.onValueChanged.AddListener(OnVolumeChanged);

    private void OnDisable() =>
        _volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);

    private void OnVolumeChanged(float value) =>
        AudioListener.volume = value;
}