using UnityEngine;

[CreateAssetMenu(fileName = nameof(EnemyDataConfig),menuName = "SO/" + nameof(EnemyDataConfig))]
public class EnemyDataConfig : ScriptableObject, IEnemyData
{
    [SerializeField] private string _name;
    [SerializeField][TextArea] private string _description;
    [SerializeField] private Sprite _preview;
    [SerializeField] private bool _opened;

    public string Name => _name;
    
    public string Description => _description;

    public Sprite Preview => _preview;

    public bool Opened => _opened;
}