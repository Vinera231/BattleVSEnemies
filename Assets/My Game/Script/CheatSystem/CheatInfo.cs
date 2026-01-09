using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheatInfo : MonoBehaviour
{
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private VerticalLayoutGroup _verticalLayout;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake() =>
        ClearInfo();

    public void ClearInfo()
    {
        _text.text = string.Empty;
        Scroll();
    }

    public void AddInfo(string text)
    {
        if (string.IsNullOrEmpty(text) == false)
            _text.text += $"{text}\n";

        Scroll();
    }

    private void Scroll()
    {
        UpdateLayout();

        Canvas.ForceUpdateCanvases();
        _scrollRect.verticalNormalizedPosition = 0f;
    }

    private void UpdateLayout()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(_verticalLayout.GetComponent<RectTransform>());

        if (_verticalLayout != null)
        {
            _verticalLayout.CalculateLayoutInputVertical();
            _verticalLayout.SetLayoutVertical();
        }

        _text.ForceMeshUpdate();
    }
}