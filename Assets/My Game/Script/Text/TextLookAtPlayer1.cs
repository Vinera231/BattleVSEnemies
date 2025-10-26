using UnityEngine;

public class TextLookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform _players;
    [SerializeField] private float _rotationSpeed;

    private void Awake()
    {
        if (_players == null)
        {
            GameObject playerOb = GameObject.FindWithTag("Player");
            if (playerOb != null)
                _players = playerOb.transform;
        }
    }

    private void Update()
    {
        if (_players == null)
            return;

        Vector3 direction = (_players.position - transform.position).normalized;
        direction.y = 0;

        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            lookRotation *= Quaternion.Euler(0, 180, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _rotationSpeed);
        }
    }
}