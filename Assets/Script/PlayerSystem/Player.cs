
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _reader;
    [SerializeField] private Health _health;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float gravity = -8f;
    [SerializeField] private float _moveX, _moveZ;
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private bool _isGround;
    [SerializeField] private Transform _playerBody;
    [SerializeField] private float _jump = 2f;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private MedKit _kit;
    [SerializeField] private SfxPlayer _sfx;
    [SerializeField] private float _mouseSensitivity = 330f;
    [SerializeField] private Transform _camera;

    private float _xRotation = 0f;
    public event Action Died;

    private void OnEnable()
    {
        _health.Died += OnDied;
        _reader.JumpPressed += OnJump;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
        _reader.JumpPressed += OnJump;
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

        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _playerBody.Rotate(Vector3.up * mouseX);

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        _camera.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
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

    public bool TryTakeHealth(float life)
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