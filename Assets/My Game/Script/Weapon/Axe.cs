using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour, ISecondWeapon
{
    [SerializeField] private DamageDetector _detector;
    [SerializeField] private float _damage = 30f;
    [SerializeField] private Animator _animator;

    private readonly List<IDamageble> _damagebles = new();

    private void OnEnable()
    {
        _detector.Entered += OnCollisionEntered;
        _detector.Exited += OnCollisionExited;
        
    }

    private void OnDisable()
    {
        _detector.Entered -= OnCollisionEntered;
        _detector.Exited -= OnCollisionExited;

        _damagebles.Clear();
    }

    private void TakeDamage()
    {
        foreach (IDamageble damageble in _damagebles)
            damageble?.TakeDamage(_damage);
    }

    public void Attack()
    {
        _animator.SetTrigger("AttackAxe");
        TakeDamage();
    }

    private void OnCollisionEntered(Collider collider)
    {
        if (collider.TryGetComponent(out IDamageble damageble) == false)
            return;

        _damagebles.Add(damageble);

        Debug.Log($"топор зашел {collider.name}");
    }

    private void OnCollisionExited(Collider collider)
    {
        if (collider.TryGetComponent(out IDamageble damageble) == false)
            return;

        _damagebles.Remove(damageble);

        Debug.Log($"топор вышел {collider.name}");
    }
}