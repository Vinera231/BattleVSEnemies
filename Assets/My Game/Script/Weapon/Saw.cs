using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour, ISecondWeapon
{
    [SerializeField] private DamageDetector _detector;
    [SerializeField] private Transform _bigDisk;
    [SerializeField] private Transform _smallDisk;
    [SerializeField] private Vector3 _rotationAxis = Vector3.right;
    [SerializeField] private float _speedRotationBigDisk;
    [SerializeField] private float _speedRotationSmallDisk;
    [SerializeField] private bool _isRotation;
    [SerializeField] private float _damageInterval;
    [SerializeField] private float _damage = 20f;

    private Coroutine _coroutine;
    private WaitForSeconds _wait;
    private readonly List<IDamageble> _damagebles = new();

    private void Awake()
    {
        _wait = new(_damageInterval);
    }

    private void Update()
    {
        if (_isRotation == false)
            return;

        _bigDisk.Rotate(_rotationAxis, _speedRotationBigDisk * Time.deltaTime, Space.Self);
        _smallDisk.Rotate(_rotationAxis, _speedRotationSmallDisk * Time.deltaTime, Space.Self);
    }

    private void OnEnable()
    {
        _detector.Entered += OnColliderEntered;
        _detector.Exited += OnColliderExited;
    }
    private void OnDisable()
    {
        _detector.Entered -= OnColliderEntered;
        _detector.Exited -= OnColliderExited;
    }

    public void Attack() =>
        StartRotation();

    public void StartRotation()
    {
        _isRotation = true;
        StartCoroutineSafe();
    }

    public void StopRotation()
    {
        StopCoroutineSafe();
        _isRotation = false;
    }

    private void OnColliderEntered(Collider collider)
    {
        if (collider.TryGetComponent(out IDamageble damageble) == false)
            return;

        _damagebles.Add(damageble);

        if (_isRotation == false)
            return;

        Debug.Log($"Объект с именем {collider.name} попал в зону поражения SAW");
    }

    private void OnColliderExited(Collider collider)
    {
        if (collider.TryGetComponent(out IDamageble damageble) == false)
            return;

        _damagebles.Remove(damageble);

        if (_isRotation == false)
            return;

        Debug.Log($"Объект с именем {collider.name} вышел из зоны поражения SAW");
    }

    private void StartCoroutineSafe()
    {
        StopCoroutineSafe();
        _coroutine = StartCoroutine(DamageRoutine());
    }

    private void StopCoroutineSafe()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator DamageRoutine()
    {
        while (_isRotation)
        {
            yield return _wait;

            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        foreach (IDamageble damageble in _damagebles)       
            damageble?.TakeDamage(_damage);

        Debug.Log($"Дамаг от пили {_damagebles.Count}");
    }
}

public interface IDamageble
{
    void TakeDamage(float value);
}