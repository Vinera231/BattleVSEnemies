using UnityEngine;

public class EnemyBossAnimator : MonoBehaviour
{
   private const string IsDied = nameof(IsDied);

    [SerializeField] private Animator _animator;

    public void PlayDied() => 
        _animator.SetBool(IsDied, true);
}