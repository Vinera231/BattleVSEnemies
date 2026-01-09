using TMPro;
using UnityEngine;

public class CheatInputField : MonoBehaviour
{
    [SerializeField] private TMP_InputField _InputField;    

    public string Text => _InputField.text;

    private void Awake() =>
        ResetText();

    public void ResetText() =>
        _InputField.text = string.Empty;
}