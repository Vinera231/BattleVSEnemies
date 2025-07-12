using TMPro;
using UnityEngine;

public class BulletViewAnim : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Animator _anim;
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
   
    public void BulletNotAnimation(float count,float max)
    {
        _text.text = $"{count}";
   
        if(_anim != null)
        {
            _anim.Play("NotBullets");
        }

    }
}
