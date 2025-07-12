using TMPro;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Animator _anim;
    [SerializeField] private  

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void UpdateBulletCount(float count, float max)
    {
        _text.text = $" {count}";

        if (_anim != null)
        {
            _anim.Play("NotBullets");
        }
    }


     
}
