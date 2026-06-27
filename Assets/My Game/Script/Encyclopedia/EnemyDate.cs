using UnityEngine;

[System.Serializable]
public class EnemyDate 
{
    public string _idEnemy;
    public string _nameEnemy;
    [TextArea]
    public string _description;
    public Sprite _iconEnemy;

    public EnemyCategory _category;

    public EnemyDate _baseEnemy;
}
