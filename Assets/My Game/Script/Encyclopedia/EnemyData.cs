using System;
using UnityEngine;

[Serializable]
public class EnemyData : IEnemyData
{
    private readonly string _name;
    private readonly string _description;
    private readonly Sprite _preview;
    private bool _opened;

    public EnemyData(IEnemyData enemyData)
    {
        _name = enemyData.Name;
        _description = enemyData.Description;
        _preview = enemyData.Preview;
        _opened = enemyData.Opened;
    }

    public string Name => _name;

    public string Description => _description;

    public Sprite Preview => _preview;

    public bool Opened => _opened;

    public void SetOpenedStatus(bool opened) =>  
        _opened = opened;   
}
