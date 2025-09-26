using UnityEngine;

public class ExplorelSpeedy : Enemy
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionDamage;
    [SerializeField] private float _exploreltime = 3f;

    protected override void Awake()
    {
        base.Awake();
        Invoke(nameof(ProcessDied), _exploreltime);
    }
    protected override void ProcessDied()
    {
        ParticleSpawner.Instance.CreateExplosion(transform.position);
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (var hit in hits)
            if(hit.TryGetComponent(out Player player))        
                player.TakeDamage(_explosionDamage);

        base.ProcessDied();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }

}