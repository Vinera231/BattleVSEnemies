using UnityEngine;

public interface IEnemyData
{
    public string Name { get; }
    public string Description { get; }
    public Sprite Preview { get; }
    public bool Opened { get; }
}