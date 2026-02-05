using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _reader;
    [SerializeField] private Health _health;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private SfxPlayer _sfx;
    [SerializeField] private float gravity = -8f;
    [SerializeField] private float _moveX, _moveZ;
    [SerializeField] private float _speed = 8f;
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private bool _isGround;
    [SerializeField] private float _jump = 2f;
    [SerializeField] private float _slowDelay;
    [SerializeField] private float _currentSpeed;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material _frostSkin;
    [SerializeField] private Material _defultSkin;
    [SerializeField] private List<MonoBehaviour> _secondWeapons;
    [SerializeField] private GunBase _gun;

    private bool _canJump = true;
    private bool _isSlow;
    private int _allowedAttackCounter = 1;

    public event Action Died;

    private void Start()
    {
        _currentSpeed = _speed;
    }

    private void OnEnable()
    {
        _health.Died += OnDied;
        _reader.JumpPressed += OnJump;
        _reader.ShotPressed += OnShotPressed;
        _reader.ShotUnpressed += OnShotUnpressed;
        _reader.SecondWeaponPressed += OnSecondAttackPressed;
        _reader.SecondWeaponUnpressed += OnSecondAttackUnpressed;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
        _reader.JumpPressed -= OnJump;
        _reader.ShotPressed -= OnShotPressed;
        _reader.ShotUnpressed -= OnShotUnpressed;
        _reader.SecondWeaponPressed -= OnSecondAttackPressed;
        _reader.SecondWeaponUnpressed -= OnSecondAttackUnpressed;
    }

    private void Update()
    {
        _isGround = _controller.isGrounded;

        if (_isGround && _velocity.y < 0)
            _velocity.y = -2f;

        _moveX = Input.GetAxis("Horizontal");
        _moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * _moveX + transform.forward * _moveZ;
        _controller.Move(_speed * Time.deltaTime * move);

        _velocity.y += gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);

        _velocity.y += gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }

    public void SetGun(GunBase gun)
    {
        _gun.gameObject.SetActive(false);
        _gun = gun;
        _gun.gameObject.SetActive(true);
    }

    public void AllowAttack() =>
        _allowedAttackCounter++;

    public void ProhibitAttack()
    {
        _bulletSpawner.StopShoot();
        _allowedAttackCounter--;
    }

    public void AllowJump() =>
        _canJump = true;

    public void ProhibitJump()
    {
        _canJump = false;
        OffJump();
    }

    public void OnJump()
    {
        if (_isGround && _canJump)
            _velocity.y = Mathf.Sqrt(_jump * -2f * gravity);
    }

    public void OffJump()
    {
        if (_velocity.y > 0)
            _velocity.y = 0f;
    }

    public void IncreaseSpeed(int amount)
    {
        _speed += amount;

        if (ParticleSpawner.Instance != null)
        {
            Debug.Log("Spawn is doing ");
            ParticleSpawner.Instance.CreateSpeed(transform.position);
        }

    }

    public void ReseteToBaseSpeed(int amount) =>
          _speed -= amount;

    public bool TryReplenishBullet(int amount)
    {
        if (_bulletSpawner.IsFull == false)
        {
            _bulletSpawner.AddBullet(amount);
            return true;
        }
        return false;
    }

    public bool TryTakeHealth(int life)
    {
        if (_health.IsFull == false)
        {
            _health.RecoverHealth(life);
            _sfx.PlayRecoverPlayer();
            return true;
        }

        return false;
    }

    public void IncreaseBulletDamage(int amount)
    {
        if (_bulletSpawner != null)
            _bulletSpawner.IncreaseBulletDamage(amount);
    }

    public void ResetBulletDamage()
    {
        ResetBulletDamage();
        if (_bulletSpawner != null)
            _bulletSpawner.ResetBulletDamage();
    }

    public void TakeDamage(float value)
    {
        _health.TakeDamage(value);
    }

    public void AfterSlowPlayer()
    {
        _speed = _currentSpeed;
        _isSlow = false;
        _renderer.material = _defultSkin;
    }

    public void SlowPlayer()
    {
        Debug.Log("_isSlow");
        if (_isSlow)
            return;

        _isSlow = true;

        _speed *= 0.5f;
        _renderer.material = _frostSkin;

        Invoke(nameof(AfterSlowPlayer), _slowDelay);
    }

    private void OnDied()
    {
        Died?.Invoke();
        _sfx.PlayDiePlayerSound();
    }

    private void OnShotPressed()
    {
        if (PauseSwitcher.Instance.IsPaused)
            return;

        if (_allowedAttackCounter > 0)
            _bulletSpawner.StartShoot(_gun.SpawnPoint);
    }

    private void OnShotUnpressed() =>
        _bulletSpawner.StopShoot();

    private void OnSecondAttackPressed()
    {
        if (PauseSwitcher.Instance.IsPaused)
            return;

        if (_allowedAttackCounter <= 0)
            return;

        foreach (MonoBehaviour weapon in _secondWeapons)
            if (weapon.gameObject.activeSelf)
                if (weapon is ISecondWeapon secondWeapon)
                    secondWeapon.Attack();
    }

    private void OnSecondAttackUnpressed()
    {
        foreach (MonoBehaviour weapon in _secondWeapons)
            if (weapon.gameObject.activeSelf)
                if (weapon is Saw saw)
                    saw.StopRotation();
    }
}