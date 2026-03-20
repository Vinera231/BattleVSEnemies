using UnityEngine;

public class CommandEasyMod : CheatCommandInfo
{
    [SerializeField] private CustomSceneManager _sceneManager;

    public override void Apply() =>
         _sceneManager.LoadEasyMode(); 
}
