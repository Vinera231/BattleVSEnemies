using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour, ISecondWeapon
{
    private static readonly int s_attackAnimationID = Animator.StringToHash("AttackAxe");

    [SerializeField] private DamageDetector _detector;
    [SerializeField] private float _damage = 30f;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _reloadTime = 0.2f;

    private readonly List<IDamageble> _damagebles = new();
    private float _remainingReloadTime;

    private void Update()
    {
        if (_remainingReloadTime <= 0)
            return;
        
        _remainingReloadTime -= Time.deltaTime;
    }
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
        if (_remainingReloadTime > 0)
            return;

        _remainingReloadTime = _reloadTime;

        _animator.Play(s_attackAnimationID, -1,0);
        TakeDamage();
        SfxPlayer.Instance.PlayAxeSound();
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