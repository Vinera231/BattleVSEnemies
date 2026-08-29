using UnityEngine;

public class DrinkPotionAnimation : MonoBehaviour
{
    private readonly int s_drinkAnimationID = Animator.StringToHash("DrinkPotion");

    [SerializeField] private Animator _animator;
    [SerializeField] private Enemy _enemy;

    public void OnDrinkHealthAnimation()
    {
        _animator.Play(s_drinkAnimationID, -1, 0);
    }
}
