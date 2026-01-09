using UnityEngine;

public class CommandAddScore : CheatCommandInfo
{
    [SerializeField] private Score _score;
    [SerializeField] private int _takeScore;

    public override void Apply() =>
      _score.Increaze(_takeScore);
}