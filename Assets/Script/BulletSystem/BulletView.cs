using TMPro;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject[] _bulletGui;
    [SerializeField] private Animator _anim;
   
    [SerializeField] private float FirstTreshold = 66f;
    [SerializeField] private float SecondTreshold = 33f;
    [SerializeField] private float ThirdTreshold = 0f;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void UpdateBulletCount(float count, float max)
    {
        _text.text = $" {count}";

        if (_bulletGui.Length > 0)
            _bulletGui[0].SetActive(count >= FirstTreshold);

        if (_bulletGui.Length > 0)
            _bulletGui[1].SetActive(count >= SecondTreshold);

        if (_bulletGui.Length > 0)
            _bulletGui[2].SetActive(count >= SecondTreshold);
    }

    public void BulletNotAnimation()
    {
        if (_anim != null)
        {
            _anim.Play("NotBullets");
        }
    }
}