using UnityEngine;

public class MainMenuAnimation : MonoBehaviour
{
  private const string StopAnim =nameof(StopAnim);

    [SerializeField] private Animator _animator;
    [SerializeField] private float _stopAnimator;

    private void Start()
    {
        _animator.SetFloat(StopAnim,_stopAnimator);
    }
}
