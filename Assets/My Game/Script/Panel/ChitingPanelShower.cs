using UnityEngine;

public class ChitingPanelShower : MonoBehaviour
{
    [SerializeField] private CheatConsoleUI _cheatConsoleUI;
    [SerializeField] private ButtonInformer _closeButton;
    [SerializeField] private InputReader _reader;
    
    private bool _isActive;

    private void OnEnable()
    {
        _reader.ChitingPanelPressed += OnPanelOpened;
        _closeButton.Clicked += OnClickCloseConsole;
    }

    private void OnDisable()
    {
        _reader.ChitingPanelPressed -= OnPanelOpened;
        _closeButton.Clicked -= OnClickCloseConsole;
    }

    private void OnClickCloseConsole()=>
        _cheatConsoleUI.HideConsole();       

    private void OnPanelOpened()
    {
        _isActive = !_isActive;

        if (_isActive)
            _cheatConsoleUI.ShowConsole();
        else
            _cheatConsoleUI.HideConsole();
    }
}