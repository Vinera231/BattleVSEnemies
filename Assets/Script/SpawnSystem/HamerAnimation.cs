using UnityEngine;

public class HamerAnimation : MonoBehaviour
{
    private const string Hit = nameof(Hit);

    [SerializeField] private Animator _animator;
    [SerializeField] private Enemy _enemy;

    private void OnEnable() =>
        _enemy.Attacked += OnAttack;
    

    private void OnDisable() =>
        _enemy.Attacked -= OnAttack;  

    private void OnAttack() =>
        _animator.SetTrigger(Hit); 
}