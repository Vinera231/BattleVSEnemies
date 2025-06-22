using UnityEngine;
using UnityEngine.UI;

public class Saver : MonoBehaviour
{
    private const string VolumeKey = "Volume";
    private const float DefaultVolume = 0.7f;

    [SerializeField] private Slider _volumeMusic;
    [SerializeField] private AudioSource _musicSource;

    private void Start() =>
        Load();

    public void Load()
    {
        float _savedVolume = PlayerPrefs.GetFloat(VolumeKey, DefaultVolume);
        _volumeMusic.value = _savedVolume;
        AudioListener.volume = _savedVolume;
    }

    public void Save()
    {
        PlayerPrefs.SetFloat(VolumeKey, _volumeMusic.value);
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit() =>
        Save();
}