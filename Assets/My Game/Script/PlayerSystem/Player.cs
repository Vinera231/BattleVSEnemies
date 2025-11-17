using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _reader;
    [SerializeField] private Health _health;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private SfxPlayer _sfx;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float gravity = -8f;
    [SerializeField] private float _moveX, _moveZ;
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private bool _isGround;
    [SerializeField] private float _jump = 2f;
    [SerializeField] private PauseSwitcher _pause;

    private bool _canAttack = true;

    public event Action Died;

    private void OnEnable()
    {
        _health.Died += OnDied;
        _reader.JumpPressed += OnJump;
        _reader.ShotPressed += OnShotPressed;
        _reader.ShotUnpressed += OnShotUnpressed;
        _pause.Continued += AllowAttack;
        _pause.Paused += ProhibitAttack;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
        _reader.JumpPressed -= OnJump;
        _reader.ShotPressed -= OnShotPressed;
        _reader.ShotUnpressed -= OnShotUnpressed;
        _pause.Continued -= AllowAttack;
        _pause.Paused -= ProhibitAttack;
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

    public void AllowAttack() =>
        _canAttack = true;

    public void ProhibitAttack()
    {
        _bulletSpawner.StopShoot();
        _canAttack = false;
    }

    public void OnJump()
    {
        if (_isGround)
            _velocity.y = Mathf.Sqrt(_jump * -2f * gravity);
    }

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

    public void TakeDamage(float value) =>
        _health.TakeDamage(value);

    private void OnDied()
    {
        Died?.Invoke();
        _sfx.PlayDiePlayerSound();
    }

    private void OnShotPressed()
    {
        if (_canAttack)
        {
            Debug.Log(_canAttack);
            _bulletSpawner.StartShoot();
        }
    }

    private void OnShotUnpressed() =>   
        _bulletSpawner.StopShoot();
}