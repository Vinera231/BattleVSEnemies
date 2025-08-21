using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void LateUpdate()
    {
        if (_target != null)
        transform.SetPositionAndRotation(_target.position, _target.rotation);
    }
}