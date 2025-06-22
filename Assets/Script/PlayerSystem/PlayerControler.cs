using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float gravity = -8f;
    [SerializeField] private float _moveX, _moveZ;
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private bool _isGround;
    [SerializeField] private float _move;
    [SerializeField] private float _mouseSensitivity = 330f;
    [SerializeField] private Transform _playerBody;
    [SerializeField] private float _jump = 2f;
    [SerializeField] private Transform JumpForce;

    public event Action Died;

    private void OnEnable() =>
        _health.Died += OnDied;

    private void OnDisable() =>
        _health.Died -= OnDied;

    private void Update()
    {
        _isGround = _controller.isGrounded;

        if (_isGround && _velocity.y < 0)
            _velocity.y = -2f;

        _moveX = Input.GetAxis("Horizontal");
        _moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * _moveX + transform.forward * _moveZ;
        _controller.Move(_speed * Time.deltaTime * move);

        if (_isGround && Input.GetKeyDown(KeyCode.Space))
            _velocity.y = Mathf.Sqrt(_jump * -2f * gravity);

        _velocity.y += gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        _playerBody.Rotate(Vector3.up * mouseX);
    }

    public void TakeDamage(float value) =>
        _health.TakeDamage(value);

    private void OnDied() =>
        Died?.Invoke();
}