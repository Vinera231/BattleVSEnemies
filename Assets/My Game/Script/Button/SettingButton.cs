using UnityEngine;

public class SettingButton : MonoBehaviour
{
    [SerializeField] private ButtonInformer _informer;
    [SerializeField] private SettingsPanel _settingsPanel;

    private void OnEnable()
    {
        _informer.Clicked += OnClick;
    }

    private void OnDisable()
    {
        _informer.Clicked -= OnClick;
    }
    
    private void OnClick()
    {
        _settingsPanel.Show();
    }
        
}