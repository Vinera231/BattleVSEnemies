using TMPro;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private const string IsEnoughBullet = nameof(IsEnoughBullet);

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject[] _bulletGui;
    [SerializeField] private Animator _anim;

    [SerializeField] private float FirstTreshold = 66f;
    [SerializeField] private float SecondTreshold = 33f;

    public void UpdateBulletCount(float count, float max)
    {
        _text.text = $" {count}";

        if (_bulletGui.Length > 0)
            _bulletGui[0].SetActive(count >= FirstTreshold);

        if (_bulletGui.Length > 0)
            _bulletGui[1].SetActive(count >= SecondTreshold);

        _anim.SetBool(IsEnoughBullet, count < 10);

        FindFirstObjectByType<BossAbilitiy>()?.UpdateBulletCount(count);
    }
}