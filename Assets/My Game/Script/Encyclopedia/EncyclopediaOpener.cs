using System.Collections.Generic;
using UnityEngine;

public class EncyclopediaOpener : MonoBehaviour
{
    [SerializeField] private WaveManager _wave;
    [SerializeField] private Encyclopedia _encyclopedia;

    private JsonSaver _saver;

    private void Awake() =>
        _saver = new();

    private void OnEnable() =>
        _wave.EnemySpawned += OnEnemySpawned;

    private void OnDisable() =>
        _wave.EnemySpawned -= OnEnemySpawned;

    private void OnDestroy() =>
        _saver.Save();

    private void OnEnemySpawned(Enemy enemy)
    {
        List<SavesEnemyData> datas = _saver.Data.Datas;

        bool contains = false;

        foreach(SavesEnemyData data in datas)
        {
            if(data.Name == enemy.Data.Name)
                contains = true;
        }

        if (contains == false)
        {
            SavesEnemyData data = new();
            data.Name = enemy.Data.Name;
            data.Opened = true;
            datas.Add(data);
        }
    }
}