using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private Slider _volumeSlider;

    private void Awake()
    {
        _musicSource.volume = _volumeSlider.value;
     }

    private void OnEnable()
    {
         _volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnDisable()
    {
        _volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
    }

    private void OnVolumeChanged(float value)
    {
        _musicSource.volume = value;
    }
}