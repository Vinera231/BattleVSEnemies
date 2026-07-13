using UnityEngine;
using UnityEngine.UI;

public class AimHandler : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Image _sight;
    [SerializeField] private Text _text;

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(OnChanged);
        OnChanged(_toggle.isOn);
    }

    private void OnDisable() =>
        _toggle.onValueChanged.RemoveListener(OnChanged);

    private void OnChanged(bool isOn)
    {
        _sight.gameObject.SetActive(isOn);
        _text.text = isOn ? "OnAim" : "OffAim";
    }
}