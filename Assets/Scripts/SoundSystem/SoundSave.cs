using UnityEngine;
using UnityEngine.UI;

public class SoundSave : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private AudioSource _saveMusic;
    [SerializeField] private const string VolumeKey = "Volume";

    private void Start()
    {
        float _savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);
        _volumeSlider.value = _savedVolume;
        AudioListener.volume = _savedVolume;

        _volumeSlider.onValueChanged.AddListener(GetVolume);
    }

    private void GetVolume (float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat(VolumeKey, volume);
        PlayerPrefs.Save();
    }
}
