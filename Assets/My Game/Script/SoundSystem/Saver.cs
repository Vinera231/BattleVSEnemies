using UnityEngine;
using UnityEngine.UI;

public class Saver : MonoBehaviour
{
    private const string VolumeKey = "Volume";
    private const string SFXKey = "Volume";
    private const float DefaultVolume = 0.7f;

    [SerializeField] private Slider _volumeMusic;
    [SerializeField] private Slider _soundSFX;

    private void Start() =>
        Load();

    public void Load()
    {
        float volume = PlayerPrefs.GetFloat(VolumeKey, DefaultVolume);
        AudioListener.volume = volume;
        _volumeMusic.value = volume;
        
        float sound = PlayerPrefs.GetFloat(SFXKey, DefaultVolume);
        AudioListener.volume = sound;
        _soundSFX.value = sound;
    }

    public void Save()
    {
        PlayerPrefs.SetFloat(VolumeKey, _volumeMusic.value);
        PlayerPrefs.Save();
    }

    private void OnDestroy() =>
        Save();

    private void OnApplicationQuit() =>
        Save();
}