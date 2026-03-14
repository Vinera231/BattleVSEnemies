using System;
using TMPro;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private const string IsEnoughBullet = nameof(IsEnoughBullet);

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject[] _bulletGui;
    [SerializeField] private Animator _anim;
    [SerializeField] private BulletSpawner _spawner;
    [SerializeField] private float FirstTreshold = 66f;
    [SerializeField] private float SecondTreshold = 33f;

    private void OnEnable()
    {
        OnBulletChanged();
        _spawner.BulletChanged += OnBulletChanged;
    }

    private void OnDisable() =>  
        _spawner.BulletChanged -= OnBulletChanged;
    
    private void OnBulletChanged()
    {
        int count = _spawner.BulletCount;
        _text.text = $" {count}";

        _bulletGui[0].SetActive(count >= FirstTreshold);
        _bulletGui[1].SetActive(count >= SecondTreshold);

        _anim.SetBool(IsEnoughBullet, count < 10);
    }
}
