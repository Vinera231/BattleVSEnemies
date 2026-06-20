using UnityEngine;

public class PlayerSlow : MonoBehaviour
{
    [SerializeField] private float _slowDelay;
    [SerializeField] private float _currentSpeed;
    [SerializeField] private float _speed;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material _defaultSkin;
    [SerializeField] private Material _frostSkin;
    [SerializeField] private PlayerMovement _movement;

    private float _baseSpeed;
    private bool _isSlow;

    private void Awake() =>
        _baseSpeed = _movement.Speed;

    public void AfterSlowPlayer()
    {
        _movement.Speed = _currentSpeed;
        _renderer.material = _defaultSkin;
        _isSlow = false;
    }

    public void SlowPlayer()
    {
        if (_isSlow)
            return;

        _isSlow = true;

        _movement.Speed *= 0.5f;
        _renderer.material = _frostSkin;

        Invoke(nameof(AfterSlowPlayer), _slowDelay);
    }
}