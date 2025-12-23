using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField] private float _damage = 30f;
    [SerializeField] private InputReader _reader;
    [SerializeField]private DamageDetector _damageDetector;

    private readonly List<IDamageble> _damagebles = new();

    private void OnEnable()
    {
        _damageDetector.Entered += OnCollisionEntered;
        _damageDetector.Entered += OnCollisionExited;
        _reader.SecondWeaponPressed += OnAttackPressed;
        _reader.SecondWeaponUnpressed += OnAttackUnpressed;
    }

    private void OnDisable()
    {
        _damageDetector.Entered -= OnCollisionEntered;
        _damageDetector.Entered -= OnCollisionExited;
        _reader.SecondWeaponPressed -= OnAttackPressed;
        _reader.SecondWeaponUnpressed -= OnAttackUnpressed;
    }


    private void OnCollisionEntered(Collider collider)
    {
        if (collider.TryGetComponent(out IDamageble damageble) == false)
            return;
            _damagebles.Add(damageble);
    }

    private void OnCollisionExited(Collider collider)
    {
        if (collider.TryGetComponent(out IDamageble damageble) == false)
           return;
            _damagebles.Remove(damageble);
    }
    private void OnAttackUnpressed()
    {
        TakeDamage();
    }

    private void OnAttackPressed()
    {
        
    }

    private void TakeDamage()
    {
        foreach (var damageble in _damagebles)
            damageble?.TakeDamage(_damage);
    }

}
