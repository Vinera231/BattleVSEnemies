using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private InputReader _reader;   
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerShooting _shooting;
    [SerializeField] private PlayerAttack _attack;
    [SerializeField] private PlayerTakeDamage _takeDamage; 
    [SerializeField] private Material _brownSkin;
    [SerializeField] private Renderer _renderer;

    private void OnEnable()
    {
        _reader.JumpPressed += OnJump;
        _reader.ShotPressed += OnShotPressed;
        _reader.ShotUnpressed += OnShotUnpressed;
        _reader.SecondWeaponPressed += OnSecondAttackPressed;
        _reader.SecondWeaponUnpressed += OnSecondAttackUnpressed;
    }


    private void OnDisable()
    {
        _reader.JumpPressed -= OnJump;
        _reader.ShotPressed -= OnShotPressed;
        _reader.ShotUnpressed -= OnShotUnpressed;
        _reader.SecondWeaponPressed -= OnSecondAttackPressed;
        _reader.SecondWeaponUnpressed -= OnSecondAttackUnpressed;
    }
    private void OnSecondAttackPressed()
    {
        _attack.SecondAttackPressed();
    }

    private void OnSecondAttackUnpressed()
    {
        _attack.SecondAttackUnpressed();
    }
    private void OnShotUnpressed()
    {
        _shooting.ShotUnpressed();
    }

    private void OnShotPressed()
    {
        _shooting.ShotPressed();
    }

    public void OnJump()
    {
        _movement.Jump();
    }

    public void ChangedColor() =>
        _renderer.material = _brownSkin;
}
