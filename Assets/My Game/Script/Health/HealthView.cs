using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private GameObject _hpBar;

    public void ShowInfo(float value, float maxHealth) =>
        _image.fillAmount = value / maxHealth;

    public void ShowHealthView() =>
       _hpBar.SetActive(true);

    public void HideHealthView() =>
        _hpBar.SetActive(false);
}