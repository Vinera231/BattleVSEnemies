using Unity.VisualScripting;
using UnityEngine;

public class ExplorelBulett : Bullet
{
    [SerializeField] private float _radiousExplorel;
    [SerializeField] private float _explorelDamage;

    private bool _hasExplorel = false;

    protected override void OnCollisionEnter(Collision collision)
    {
        if (!_hasExplorel && collision.gameObject.TryGetComponent(out BulletIgnore _) == false)
            Exploed();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (!_hasExplorel && other.gameObject.TryGetComponent(out BulletIgnore _) == false)
            Exploed();
    }

    private void Exploed()
    {
        if (_hasExplorel)
            return;
        
        _hasExplorel = true;

        ParticleSpawner.Instance.CreateExplosion(transform.position);

        Collider[] hits = Physics.OverlapSphere(transform.position, _radiousExplorel);
      
        foreach (var hit in hits)
            if(hit.TryGetComponent(out Enemy enemy))
                enemy.TakeDamage(_explorelDamage + Damage);

        Destroy(gameObject);
    }
}