using UnityEngine;

public class CommandSkipWave : CheatCommandInfo
{
    [SerializeField] private WaveManager _waveManager;
    [SerializeField] private int _skipWave;

    public override void Apply()
    {
      // _waveManager.StartWave(_skipWave);
    }
}
