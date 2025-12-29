using UnityEngine;
using UnityEngine.UI;

public class CameraSetting : MonoBehaviour
{
  
    [Header("Reference")]
    [SerializeField] private Slider _sensetiveSlider;
    [SerializeField] private CameraRotator _follower;
    [SerializeField] private Transform _playerBody;

    [Header("Setting")]
    [SerializeField] private float _minSensitive = 250f;
    [SerializeField] private float _maxSensitive = 500f;
    [SerializeField] private float _defaultSensitivity = 330f;

    private void Start()
    {
        float savedSensitive = PlayerPrefs.GetFloat("MouseSensitive", _defaultSensitivity);

        if (_sensetiveSlider)
        {
            _sensetiveSlider.minValue = _minSensitive;
            _sensetiveSlider.maxValue = _maxSensitive;
            _sensetiveSlider.value = savedSensitive;

            _sensetiveSlider.onValueChanged.AddListener(UpdateSensitive);
        }
    
        if(_follower)
            _follower.SetSensetive(savedSensitive);
    }

     public void UpdateSensitive(float value)
    {
        PlayerPrefs.GetFloat("MouseSensitive", value);

        if (_follower)
            _follower.SetSensetive(value);
    }
}