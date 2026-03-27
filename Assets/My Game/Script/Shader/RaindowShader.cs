using UnityEngine;

public class RaindowShader : MonoBehaviour
{
    Renderer rend;
    void Start() =>
        rend = GetComponent<Renderer>();
    
    private void Update()
    {
        Vector3 viewDir = (Camera.main.transform.position - transform.position).normalized;

        float t = Time.time + Vector3.Dot(transform.up, viewDir);

        Color rainbow = new Color(
            Mathf.Sin(t) * 0.5f * 0.5f,
            Mathf.Sin(t + 2f) * 0.5f * 0.5f,
            Mathf.Sin(t + 4f) * 0.5f * 0.5f
           );

        rend.material.color = rainbow;
    }
}
