
using UnityEngine;

public class CamerZoom : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private QuietPlace _quietPlace;
    [SerializeField] private InputReader _reader;
    [SerializeField] private float _zoomSpeed = 10f;
    [SerializeField] private float _minFov = 30f;
    [SerializeField] private float _maxFov = 60f;

    private bool _canZoom;
    private float _defaultFov = 60;

    private void Awake() =>  
        _defaultFov = _camera.fieldOfView;
    
    private void OnEnable()
    {
        _reader.MouseScroll += OnMouseScroll;
        _quietPlace.PlayerEntered += EnableZoom;
        _quietPlace.PlayerExited += DisableZoom;
    }
  
    private void OnDisable()
    {
        _reader.MouseScroll -= OnMouseScroll;
        _quietPlace.PlayerEntered -= EnableZoom;
        _quietPlace.PlayerExited -= DisableZoom;
    }

    private void OnMouseScroll(float value)
    {
        if (_canZoom == false)
            return;

        float zoom =_camera.fieldOfView + value * _zoomSpeed;
        _camera.fieldOfView =  Mathf.Clamp(zoom,_minFov,_maxFov);
    }

    private void EnableZoom()
    {
        _canZoom = true;
    }

    private void DisableZoom()
    {
        _canZoom = false;
        _camera.fieldOfView = _defaultFov;
    }
}