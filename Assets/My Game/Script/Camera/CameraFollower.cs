using UnityEngine;

public class CameraFollower : MonoBehaviour
{
 
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _playerBody;
    [SerializeField] private float _mouseSensitivity = 330f;
    [SerializeField] private float _smoothRotation = 20f;

    private float _xRotation = 0f;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _playerBody.Rotate(Vector3.up * mouseX);

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        _target.localRotation = Quaternion.Euler(_xRotation,0f, 0f);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("MouseSensetive"))
            _mouseSensitivity = PlayerPrefs.GetFloat("MouseSensetive");
    }
    private void LateUpdate()
    {
        if (_target != null)
        {
          transform.SetPositionAndRotation(_target.position, _target.rotation);
          transform.position = Vector3.Lerp(transform.position,
         _target.position,_smoothRotation* Time.deltaTime);
        }
    }
  
    public void SetSensetive(float value)
    {       
        _mouseSensitivity = value;
    }
}