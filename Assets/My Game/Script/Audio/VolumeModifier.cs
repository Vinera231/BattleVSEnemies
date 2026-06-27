using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeModifier : MonoBehaviour
{
    private const float MinimumLevel = -80;
    private const float MaximumLevel = 20;

    private const string Music = nameof(Music);
    private const string Sound = nameof(Sound);

    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Image _onMusic;
    [SerializeField] private Image _offMusic;
    [SerializeField] private Image _onSound;
    [SerializeField] private Image _offSound;

    private float _minimumValueSlider;
    private float _maximumValueSlider;
    private float _normolized;

    private void Start()
    {
        _minimumValueSlider = _musicSlider.minValue;
        _maximumValueSlider = _musicSlider.maxValue;

        OnChangedMusic(_musicSlider.value);
        OnChangedSound(_soundSlider.value);
    }

    private void OnEnable()
    {
        _musicSlider.onValueChanged.AddListener(OnChangedMusic);
        _soundSlider.onValueChanged.AddListener(OnChangedSound);
    }

    private void OnDisable()
    {
        _musicSlider.onValueChanged.RemoveListener(OnChangedMusic);
        _soundSlider.onValueChanged.RemoveListener(OnChangedSound);
    }

    private void OnChangedMusic(float value)
    {
        SetLevel(Music, value);
        _normolized = NormalizeValue(value);
        
        if(Mathf.Approximately(_normolized, 0f))
        {
            _onMusic.enabled = false;
            _offMusic.enabled = true;
        }
        else
        {
            _onMusic.enabled = true;
            _offMusic.enabled = false;
        }
    }

    private void OnChangedSound(float value)
    {
        SetLevel(Sound, value);
        _normolized = NormalizeValue(value);

        if (Mathf.Approximately(_normolized, 0f))
        {
            _onSound.enabled = false;
            _offSound.enabled = true;
        }
        else
        {
            _onSound.enabled = true;
            _offSound.enabled = false;
        }
    }

    private void SetLevel(string group, float value)
    {
        float level = ConvertVolumeToLevel(NormalizeValue(value));
        _mixer.SetFloat(group, level);
    }
   
    private float NormalizeValue(float value) =>
        Mathf.InverseLerp(_minimumValueSlider, _maximumValueSlider, value);

    private float ConvertVolumeToLevel(float value) =>
        value == 0 ? MinimumLevel : Mathf.Log10(value) * MaximumLevel;
}
