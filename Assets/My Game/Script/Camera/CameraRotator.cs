using System;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 330f;
    [SerializeField] Transform _target;
    [SerializeField, Range(-90f, 0f)] private float _minimumVerticalAngle = -90f;
    [SerializeField, Range(0f, 90f)] private float _maximumVerticalAngle = 30f;

    private float _currentHorizontalRotation;
    private float _currentVerticalRotation;

    private void LateUpdate() =>
        ProcessRotationInput(Time.deltaTime);

    public void SetSensetive(float savedSensitive) =>
        _mouseSensitivity = savedSensitive;

    private void ProcessRotationInput(float deltaTime)
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * deltaTime;

        UpdateHorizontalRotation(mouseX);
        UpdateVerticalRotation(mouseY);
        ApplyRotations();
    }

    private void UpdateHorizontalRotation(float mouseX) =>
        _currentHorizontalRotation += mouseX;

    private void UpdateVerticalRotation(float mouseY)
    {
        _currentVerticalRotation -= mouseY;
        _currentVerticalRotation = Mathf.Clamp(_currentVerticalRotation, _minimumVerticalAngle, _maximumVerticalAngle);
    }

    private void ApplyRotations()
    {
        ApplyPlayerRotation();
        ApplyCameraRotation();
    }

    private void ApplyPlayerRotation()
    {
        Quaternion targetRotation = Quaternion.Euler(0f, _currentHorizontalRotation, 0f);
        _target.rotation = targetRotation;
    }

    private void ApplyCameraRotation()
    {
        Quaternion targetRotation = Quaternion.Euler(_currentVerticalRotation, 0f, 0f);
        transform.localRotation = targetRotation;
    }
}