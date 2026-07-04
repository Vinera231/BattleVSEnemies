using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Encyclopedia : MonoBehaviour
{
    [SerializeField] private List<EnemyDataConfig> _configs;

    private List<EnemyData> _openedDatas = new();
    private JsonSaver _saver;

    public event Action Changed;

    public IEnemyData CurrentData => _openedDatas.Count > 0 ? _openedDatas[Index] : null;

    public int Index { get; private set; }

    private void Awake()
    {
        _saver = new JsonSaver();
        List<SavesEnemyData> savesData = _saver.Data.Datas;
        _openedDatas.Clear();

        foreach (EnemyDataConfig config in _configs)
            _openedDatas.Add(new(config));

        foreach (SavesEnemyData saveData in savesData)
        {
            foreach (EnemyData openedData in _openedDatas)
            {
                if (saveData.Name == openedData.Name)
                    openedData.SetOpenedStatus(saveData.Opened);
            }
        }

        _openedDatas = _openedDatas
            .Where(data => data.Opened)
            .ToList();
        
        Changed?.Invoke();
    }

    public IEnemyData GetData(int index)
    {
        if (index < 0 || index >= _openedDatas.Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        return _openedDatas[index];
    }

    public void Previous()
    {
        if (_openedDatas.Count == 0)
            return;

        Index = (Index - 1 + _openedDatas.Count) % _openedDatas.Count;

        Changed?.Invoke();
    }

    public void Next()
    {
        if (_openedDatas.Count == 0)
            return;

        Index = (Index + 1) % _openedDatas.Count;

        Changed?.Invoke();
    }
}
