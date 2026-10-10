using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static  class SaverSystem
{
    public static string SavePath =>
        Path.Combine(Application.persistentDataPath, "themes.json");

    public static void Unlock(int index)
    {
        ThemeData data = Load();
        if (data.UnlockedThemes.Contains(index))
            return;

        data.UnlockedThemes.Add(index);
        Save(data);
    }

    public static bool isUnlocked(int index)
    {
        ThemeData data = Load();
        return data.UnlockedThemes.Contains(index);   
    }

    public static int GetSelectTheme()
    {
        return Load().SelectedThemes;
    }

    public static void Select(int index)
    {
        ThemeData data = Load();

        if (data.UnlockedThemes.Contains(index) == false)
            return;

        data.SelectedThemes = index;
        Save(data);
    }

    private static ThemeData Load()
    {
        if(File.Exists(SavePath) == false)
            return new ThemeData();

        string json = File.ReadAllText(SavePath);
        ThemeData data = JsonUtility.FromJson<ThemeData>(json);

        if (data == null)
            return new ThemeData();

        if(data.UnlockedThemes == null)
            data.UnlockedThemes = new List<int> ();

        if(data.UnlockedThemes.Contains(0) == false)
            data.UnlockedThemes.Add(0);

        return data;
    }

    private static void Save(ThemeData data)
    {
        string json = JsonUtility.ToJson(data,true);
        File.WriteAllText(SavePath, json);
    }

    private class ThemeData
    {
        public List<int> UnlockedThemes = new List<int> { 0 };
        public int  SelectedThemes;
    }
}