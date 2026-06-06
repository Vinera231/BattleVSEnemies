using UnityEngine;

public class HealthIcon : MonoBehaviour
{
    [SerializeField] private GameObject[] _icon;
    [SerializeField] private Health _health;
    [SerializeField] private float _firstHealth = 100;
    [SerializeField] private float _secondHealth = 80;
    [SerializeField] private float _thirtHealth = 60;
    [SerializeField] private float _forthHealth = 40;
    [SerializeField] private float _fifthHealth = 20;

    private void OnEnable() =>
        _health.ValueChanged += OnHealthChanged;

    private void OnDisable() =>
        _health.ValueChanged -= OnHealthChanged;

    private void OnHealthChanged(float value)
    {
        foreach (var icon in _icon)
            icon.SetActive(false);

        if (value >= _firstHealth)
            _icon[0].SetActive(true);
        else if (value >= _secondHealth)
        {
            _icon[1].SetActive(true);
            SfxPlayer.Instance.PlayBrokenGlassesSound();
        }
        else if (value >= _thirtHealth)
            _icon[2].SetActive(true);
        else if (value >= _forthHealth)
            _icon[3].SetActive(true);
        else if (value >= _fifthHealth)
        {
            _icon[4].SetActive(true);
            SfxPlayer.Instance.PlayBleedSound();
        }
    }
}