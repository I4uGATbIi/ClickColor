using Definitions;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class PrefabsLoader
{
    private static PrefabsList prefabNames;

    public static void Load()
    {
        string json = File.ReadAllText(BaseDefinitions.PathToPrefabsJson);
        prefabNames = JsonUtility.FromJson<PrefabsList>(json);
    }

    public static string GetRandomPrefabName()
    {
        if(prefabNames == null)
        {
            Load();
        }
        return prefabNames.names.PickRandom();
    }

    public static List<string> GetAllNames()
    {
        if(prefabNames == null)
        {
            Load();
        }
        return new List<string>(prefabNames.names);
    }
}

[Serializable]
public class PrefabsList
{
    public List<string> names;
}
