using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HealthIcon : MonoBehaviour
{
    [SerializeField] private GameObject[] _icon;
    [SerializeField] private Health _health;
    [SerializeField] private float _firstHealth = 100;
    [SerializeField] private float _secondHealth = 80;
    [SerializeField] private float _thirtHealth = 60;

    private void OnEnable() =>
        _health.ValueChanged += OnHealthChanged;

    private void OnDisable() =>
        _health.ValueChanged -= OnHealthChanged;

    private void OnHealthChanged(float value)
    {
        if (value >= _firstHealth)
            _icon[0].SetActive(true);
        else if (value >= _secondHealth)
        {
            _icon[1].SetActive(value >= _secondHealth);
            SfxPlayer.Instance.PlayBrokenGlassesSound();
        }
        else if (value >= _thirtHealth)
        _icon[2].SetActive(value >= _thirtHealth);
    }
}
