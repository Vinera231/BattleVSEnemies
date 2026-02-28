using UnityEngine;

public class HamerAnimation : MonoBehaviour
{
    private static readonly int s_attackAnimationID = Animator.StringToHash("Kick");
   
    [SerializeField] private Animator _animator;
    [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        _enemy.Attacked += OnAttack;
    }

    private void OnDisable()
    {
        _enemy.Attacked -= OnAttack;
    }

    private void OnAttack()
    {
        _animator.Play(s_attackAnimationID, -1, 0);
        OnHammerHit();
    }

    private void OnHammerHit()
    {
        SfxPlayer.Instance.PlayHammerEnemy();
    }
}