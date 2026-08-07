using UnityEngine;

public class RadioAnimation : MonoBehaviour
{
    private readonly int s_radioAnimationID = Animator.StringToHash("ApeelRadio");

    [SerializeField] private Animator _animator;

    public void OnAnimationRadio() =>
        _animator.Play(s_radioAnimationID, -1, 0);
}