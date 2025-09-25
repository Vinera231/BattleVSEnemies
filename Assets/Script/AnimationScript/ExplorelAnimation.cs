using System.Collections;
using UnityEngine;

public class ExplorelAnimation : MonoBehaviour
{
    private const string IsDied = nameof(IsDied);

    [SerializeField] private Animation _animation;
    [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        if (_animation != null)
            _enemy.Died += OnEnemyDied;
    }

    private void OnDisable()
    {
        if (_animation != null)
            _enemy.Died -= OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        if(_animation != null && _animation.GetClip(IsDied) != null)
        {
            _animation.Play(IsDied);
            StartCoroutine(WaitAndDestroyEnemy(_animation[IsDied].length, enemy.gameObject));
        }
        else
        {
            Destroy(enemy.gameObject);
        }
    }

    private IEnumerator WaitAndDestroyEnemy(float exploreTime, GameObject target)
    {
        yield return new WaitForSeconds(exploreTime);
        Destroy(target);
    }
}
