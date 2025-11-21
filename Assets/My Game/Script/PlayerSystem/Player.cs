using System;
using UnityEngine;
using UnityEngine.Accessibility;

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
    [SerializeField] private PauseSwitcher _pauseSwitcher;

    private int _attackCounter = 1;

    public event Action Died;
  
    private void Awake()
    {
         _pauseSwitcher.Continued += AllowAttack;
        _pauseSwitcher.Paused += ProhibitAttack;

        if (_pauseSwitcher.IsPaused)
        {
            ProhibitAttack();
        }
    }

    private void OnDestroy()
    {
        _pauseSwitcher.Continued -= AllowAttack;
        _pauseSwitcher.Paused -= ProhibitAttack;
    }

    private void OnEnable()
    {
        _health.Died += OnDied;
        _reader.JumpPressed += OnJump;
        _reader.ShotPressed += OnShotPressed;
        _reader.ShotUnpressed += OnShotUnpressed;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
        _reader.JumpPressed -= OnJump;
        _reader.ShotPressed -= OnShotPressed;
        _reader.ShotUnpressed -= OnShotUnpressed;
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

        _velocity.y += gravity * Time.deltaTime ;
        _controller.Move(_velocity * Time.deltaTime);
    }

    public void AllowAttack()
    {
        _attackCounter++;   
        Debug.Log($"Method {nameof(AllowAttack)} _attackCounter = {_attackCounter}");
    }

    public void ProhibitAttack()
    {
        _bulletSpawner.StopShoot();
        _attackCounter--;
        Debug.Log($"Method {nameof(ProhibitAttack)} _attackCounter = {_attackCounter}");
    }

    public void OnJump()
    {
        if (_isGround)
            _velocity.y = Mathf.Sqrt(_jump * -2f * gravity);
    }

    public void IncreaseSpeed(int amount)
    {
        _speed += amount;
        ParticleSpawner.Instance?.CreateSpeed(transform.position);
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

    public void TakeDamage(float value) =>
        _health.TakeDamage(value);

    private void OnDied()
    {
        Died?.Invoke();
        _sfx.PlayDiePlayerSound();
    }

    private void OnShotPressed()
    {
        if (_attackCounter > 0)       
            _bulletSpawner.StartShoot();        
    }

    private void OnShotUnpressed() =>
        _bulletSpawner.StopShoot();
}