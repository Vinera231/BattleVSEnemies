using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private ScoreView _view;
    [SerializeField] private int _score;
    
    public int Value => _score;

    public void Increaze(int value)
    {
        _score += value;
        _view.UpdateInfo(_score);
    }

    public bool TrySpendScore(int value)
    {
        if(_score < value)
            return false;

        _score -= value;
        return true;
    }

}