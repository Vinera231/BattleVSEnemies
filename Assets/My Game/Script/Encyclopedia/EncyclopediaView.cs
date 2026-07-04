using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaView : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Image _preview;
    [SerializeField] private Encyclopedia _encyclopedia;

    private void OnEnable()
    {
        _encyclopedia.Changed += UpdateInfo;
        UpdateInfo();
    }

    private void OnDisable() =>
        _encyclopedia.Changed -= UpdateInfo;

    private void UpdateInfo()
    {
        IEnemyData data = _encyclopedia.CurrentData;

        if (data == null)
        {
            _name.text = string.Empty;
            _description.text = string.Empty;
            _preview.sprite = null;
        }
        else
        {
            _name.text = data.Name;
            _description.text = data.Description;
            _preview.sprite = data.Preview;
        }
    }
}