using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private int _healthAmount;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            player.TakeHealth(_healthAmount);
            Destroy(gameObject);
        }
    }
}