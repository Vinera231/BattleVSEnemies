using UnityEngine;

public class CugleAnimation : MonoBehaviour
{
    private readonly int s_attackID = Animator.StringToHash("CugleAttack");

    [SerializeField] private Animator _animator;
    [SerializeField] private Enemy _enemy;

    private void OnEnable() =>
    _enemy.Attacked += PlayAttackCugle;

    private void OnDisable() =>
        _enemy.Attacked -= PlayAttackCugle;
 
    public void PlayAttackCugle() =>
        _animator.Play(s_attackID,-1,0);
}