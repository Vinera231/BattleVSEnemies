using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Knife _knife;
    [SerializeField] private Saw _saw;
    [SerializeField] private Axe _axe;

    public void SetSaw()
    {
        _knife.gameObject.SetActive(false);
        _saw.gameObject.SetActive(true);
        _axe.gameObject.SetActive(false);
    }
    
    public void SetAxe()
    {
        _knife.gameObject.SetActive(false);
        _saw.gameObject.SetActive(false);
        _axe.gameObject.SetActive(true);
    }   
}