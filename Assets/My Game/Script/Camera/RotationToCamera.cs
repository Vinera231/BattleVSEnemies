using UnityEngine;

public class RotationToCamera : MonoBehaviour
{
    private Transform _camera;
    private Transform _transform;

    private void Start()
    {
        _camera = FindFirstObjectByType<Camera>().transform;
        _transform = transform;
    }  

    private void LateUpdate()
    {
        if (_camera != null)
            _transform.LookAt(_camera);
    }
}
