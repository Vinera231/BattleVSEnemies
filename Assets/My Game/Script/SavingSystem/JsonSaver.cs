using System.IO;
using UnityEngine;

public class JsonSaver
{
    private const string FileName = "save.json";

    public SavesData Data;

    private string SavePath =>
        Path.Combine(Application.persistentDataPath, FileName);

    public JsonSaver()
    {
        Load();
    }

    public void Load()
    {
        if (File.Exists(SavePath))
        {
            string json = File.ReadAllText(SavePath);
            Data = JsonUtility.FromJson<SavesData>(json);

            if (Data == null)
                Data = new SavesData();
        }
        else
        {
            Data = new SavesData();
            Save(); 
        }
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(Data, true);
        File.WriteAllText(SavePath, json);
    }
}