using UnityEngine;

public class CommandGoToMenu : CheatCommandInfo
{
    [SerializeField] private CustomSceneManager _sceneManager;

    public override void Apply() =>
      _sceneManager.LoadMenu();
}
