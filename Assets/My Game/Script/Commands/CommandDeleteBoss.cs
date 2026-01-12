using UnityEngine;

public class CommandDeleteBoss : CheatCommandInfo
{
    [SerializeField] private WaveManager _waveManager;
    [SerializeField] private int _wave;

    public override void Apply() =>
       _waveManager.DeleteBoss(_wave);
}
