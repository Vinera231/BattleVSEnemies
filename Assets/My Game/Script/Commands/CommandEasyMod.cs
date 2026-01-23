using UnityEngine;
using UnityEngine.SceneManagement;

public class CommandEasyMod : CheatCommandInfo
{
    [SerializeField] private CustomSceneManager _sceneManager;

    public override void Apply() =>
         _sceneManager.LoadEasyMod(); 
}
