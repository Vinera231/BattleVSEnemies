using UnityEngine;

public class WinPanelShower : MonoBehaviour
{
    [SerializeField] private Wave _lastWave;
    [SerializeField] private WinPanel _winPanel;

    private void Awake()=>
        _winPanel.gameObject.SetActive(false);
  

    private void OnEnable()=>
        _lastWave.Finished += OnFinished;
    

    private void OnDisable()=>
        _lastWave.Finished -= OnFinished;
    

    private void OnFinished() =>
        _winPanel.gameObject.SetActive(true); 
}