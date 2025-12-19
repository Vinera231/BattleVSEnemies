using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Knife _knife;
    [SerializeField] private Saw _saw;

    public void SetSaw()
    {
        _knife.gameObject.SetActive(false);
        _saw.gameObject.SetActive(true);
    }
}