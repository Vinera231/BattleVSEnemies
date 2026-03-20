using UnityEngine;

public class CommandHardMode : CheatCommandInfo
{
    [SerializeField] private CustomSceneManager _sceneManager;

    public override void Apply() =>
         _sceneManager.LoadHardMode(); 
}
