using UnityEngine;

public class StaffAnimation : MonoBehaviour
{
    public readonly int s_attackAnimationID = Animator.StringToHash("StaffAttack");
    public readonly int s_apeelAnimationID = Animator.StringToHash("ApeelEnemy");
    public readonly int s_healthAnimationID = Animator.StringToHash("HealtApeel");

    [SerializeField] private Animator _animator;
    [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        _enemy.Attacked += OnStaffAttack;
    }
    private void OnDisable()
    {
        _enemy.Attacked -= OnStaffAttack;
    }

    public void OnStaffAttack() =>   
        _animator.Play(s_attackAnimationID,-1,0);    
   
    public void OnApeelEnemy() =>   
        _animator.Play(s_apeelAnimationID,-1,0);
   
    public void OnHealthEnemy() =>   
        _animator.Play(s_healthAnimationID,-1,0);
}