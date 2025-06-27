using UnityEngine;

public class AttackDetector : MonoBehaviour
{
    private bool _canAttack;

    public bool CanAttack => _canAttack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            _canAttack = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            _canAttack = false;
    }
}