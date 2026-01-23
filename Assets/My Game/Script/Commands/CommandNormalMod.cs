using UnityEngine;

public class CommandNormalMod : CheatCommandInfo
{
    [SerializeField] private CustomSceneManager _sceneManager;

    public override void Apply() =>
         _sceneManager.LoadNormalMod(); 
}