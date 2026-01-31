using UnityEngine;

public class CommandDeleteBoss : CheatCommandInfo
{
    [SerializeField] private WaveManager _waveManager;

    public override void Apply() =>
       _waveManager.DeleteBoss();
}
