using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _reader;
    [SerializeField] private Health _health;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private MedKit _kit;
    [SerializeField] private SfxPlayer _sfx;  
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float gravity = -8f;
    [SerializeField] private float _moveX, _moveZ;
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private bool _isGround;
    [SerializeField] private float _jump = 2f;
   
    public event Action Died;
    private bool _canMove = true;

    public void SetMove(bool state)
    {
        _canMove = state;
        if (state == false)
            _velocity = Vector3.zero;
    }

    private void OnEnable()
    {
        _health.Died += OnDied;
        _reader.JumpPressed += OnJump;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
        _reader.JumpPressed -= OnJump;
    }

    private void Update()
    {
        _isGround = _controller.isGrounded;

        if (_isGround && _velocity.y < 0)
            _velocity.y = -2f;

        if (_canMove)
        {
            _moveX = Input.GetAxis("Horizontal");
            _moveZ = Input.GetAxis("Vertical");

            Vector3 move = transform.right * _moveX + transform.forward * _moveZ;
            _controller.Move(_speed * Time.deltaTime * move);

            _velocity.y += gravity * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
         
        }
            _velocity.y += gravity * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
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

    public void TakeDamage(float value) =>
        _health.TakeDamage(value);

    private void OnDied()
    {
        Died?.Invoke();
        _sfx.PlayDiePlayerSound();
    }
}