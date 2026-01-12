using Unity.VisualScripting;
using UnityEngine;

public class ChangGun : MonoBehaviour
{
    [SerializeField] private MeshFilter _gun;
    [SerializeField] private GameObject _bananaGun;
    public void ReplaceGun(Mesh newGunMesh)
    {
        _gun.mesh = newGunMesh;
        _bananaGun.SetActive(true);
        _gun.gameObject.SetActive(false);
    }
}
