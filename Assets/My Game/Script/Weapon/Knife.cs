using System;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private DamageDetector _detector;
    [SerializeField] private float _damage = 20f;
    [SerializeField] private InputReader _reader;

    private readonly List<IDamageble> _damagebles = new();

    private void OnEnable()
    {
        _detector.Entered += OnCollisionEntered;
        _detector.Exited += OnCollisionExited;
        _reader.SecondWeaponPressed += OnAttackPressed;
        _reader.SecondWeaponUnpressed += OnAttackUnPressed;
    }

    private void OnDisable()
    {
        _detector.Entered -= OnCollisionEntered;
        _detector.Exited -= OnCollisionExited;
        _reader.SecondWeaponPressed -= OnAttackPressed;
        _reader.SecondWeaponUnpressed -= OnAttackUnPressed;

        _damagebles.Clear();
    }

    private void OnAttackPressed()
    {
        TakeDamage();
    }

    private void OnAttackUnPressed()
    {

    }

    private void TakeDamage()
    {
        foreach (IDamageble damageble in _damagebles)
            damageble?.TakeDamage(_damage);
    }

    private void OnCollisionEntered(Collider collider)
    {
        if (collider.TryGetComponent(out IDamageble damageble) == false)
            return;

        _damagebles.Add(damageble);
        Debug.Log($"Объект с именем {collider.name}  зашол зону поражения");
    }

    private void OnCollisionExited(Collider collider)
    {
        if (collider.TryGetComponent(out IDamageble damageble) == false)
            return;

        _damagebles.Remove(damageble);
        Debug.Log($"Объект с именем {collider.name} вышел из зони ");
    }
}