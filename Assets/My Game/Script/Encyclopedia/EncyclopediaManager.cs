using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EncyclopediaManager : MonoBehaviour
{
    public static EncyclopediaManager Instance;

    private HashSet<string> discoverEnemies = new HashSet<string>();

    private void Awake() =>
     Instance = this;

    public void DiscoverEnemy(EnemyDate enemyName)
    {
        if (!discoverEnemies.Contains(enemyName._idEnemy))
        {
            Debug.Log("Новая запись: ");
        }
    }

    public bool IsDiscovered(string id)
    {
        return discoverEnemies.Contains(id);
    }
}