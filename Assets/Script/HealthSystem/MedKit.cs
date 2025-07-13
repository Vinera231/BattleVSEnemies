using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private float _ramainingTime;
    [SerializeField] private int _healthAmount;
    
    private void Update()
    {
        _ramainingTime -= Time.deltaTime;

        if (_ramainingTime < 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            player.TakeHealth(_healthAmount);
            Destroy(gameObject);
        }
    }
}