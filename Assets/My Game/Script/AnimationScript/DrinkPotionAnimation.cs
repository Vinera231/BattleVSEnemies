using UnityEngine;

public class DrinkPotionAnimation : MonoBehaviour
{
    private readonly int s_drinkAnimationID = Animator.StringToHash("DrinkPotion");

    [SerializeField] private Animator _animator;
    [SerializeField] private Enemy _enemy;

    private float _amount = 5000f;

    public void OnDrinkHealthAnimation()
    {
        _animator.Play(s_drinkAnimationID, -1, 0);
        _enemy.TakeHealth(_amount);
    }
}
