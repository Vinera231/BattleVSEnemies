using UnityEngine;

public class KingBossHealth : MonoBehaviour
{
    [SerializeField] private float _radious = 10f;
    [SerializeField] private float _health = 100f;
    [SerializeField] private LayerMask _enemy;

    public  void DealHealth()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, _radious,_enemy);

        foreach(Collider hits in hit)
        {
            if(hits.TryGetComponent(out Enemy enemy))
                enemy.TakeHealth(_health);
        }
    }
}