using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private HealthView _view;
    [SerializeField] private float _maxValue;
    [SerializeField] private float _healthValue;

    public event Action<float> ValueChanged;
    public event Action Died;

    public bool IsFull => _healthValue >= _maxValue;

    public float Value => _healthValue;

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException("Значение должно быть положительное");

        _healthValue -= damage;

        _healthValue = Mathf.Max(0, _healthValue);    
        _view.ShowInfo(_healthValue, _maxValue);
        ValueChanged?.Invoke(Value);
      
        if (_healthValue == 0)
            Died?.Invoke(); 
    }

    public void RecoverHealth(float amount)
    {
        _healthValue = Mathf.Min(_healthValue + amount,_maxValue);
    
        _view.ShowInfo(_healthValue, _maxValue);
        ValueChanged?.Invoke(Value);
    }
}