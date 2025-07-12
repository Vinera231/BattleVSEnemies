using TMPro;
using UnityEngine;

public class BulletViewAnim : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
   
   
    public void BulletNotAnimation(float count,float max)
    {
        _text.text = $"{count}";
   

    }
}
