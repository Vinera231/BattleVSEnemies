using UnityEngine;

public class EnemyBossAnimator : MonoBehaviour
{
    private static readonly int s_attackAnimationID = Animator.StringToHash("BossDie");

    [SerializeField] private Animator _animator;

    public void PlayDied() => 
        _animator.Play(s_attackAnimationID,-1,0);
}