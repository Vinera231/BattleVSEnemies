using UnityEngine;

public class CommandRYTP : CheatCommandInfo
{
    [SerializeField] private Music _music;
    
    public override void Apply()
    {
        _music.PlayDadStepMusic();
    }        
}