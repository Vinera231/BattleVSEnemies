using UnityEngine;

public class HealthLookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _rotationSpeed;

    private void Awake()
    {
        if (_target == null && GameObject.FindWithTag("Player") != null)
            _target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (_target == null)
            return;

        Vector3 direction = (_target.position - transform.position).normalized;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _rotationSpeed);
        }
    }
}