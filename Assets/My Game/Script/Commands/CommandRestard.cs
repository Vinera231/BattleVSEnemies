using UnityEngine;

public class CommandRestard: CheatCommandInfo
{
    [SerializeField] private RestartGame _restartGame;

    public override void Apply() =>
      _restartGame.ResetGame();
}
