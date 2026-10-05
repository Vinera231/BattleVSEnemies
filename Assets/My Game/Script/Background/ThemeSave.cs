using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static  class ThemeSave
{
    public static string SavePath =>
        Path.Combine(Application.persistentDataPath, "themes.json");

    public static void Unlock(int index)
    {
        ThemeData data = Load();

        if (data.UnlockedThemes.Contains(index))
            return;

        data.UnlockedThemes.Add(index);

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SavePath, json);
    }

    public static bool isUnlocked(int index)
    {
        ThemeData data = Load();
        return data.UnlockedThemes.Contains(index);   
    }


    private static ThemeData Load()
    {
        if(File.Exists(SavePath) == false)
            return new ThemeData();

        string json = File.ReadAllText(SavePath);

        ThemeData data = JsonUtility.FromJson<ThemeData>(json);

        Save(data);
        return data ?? new ThemeData();
    }

    private static void Save(ThemeData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(SavePath, json);
    }

    private class ThemeData
    {
        public List<int> UnlockedThemes = new();
        public int  SelectedThemes;
    }
}