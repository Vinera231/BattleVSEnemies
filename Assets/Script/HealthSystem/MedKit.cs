using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private int _healthAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))     
            if (player.TryTakeHealth(_healthAmount))
                Destroy(gameObject);
    }
}