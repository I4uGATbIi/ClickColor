using UnityEngine;

namespace Definitions
{
    public static class BaseDefinitions
    {
        private const string PrefabJsonName = "/prefabs.json";

        private const string JsonsFolder = "/Jsons";
        private const string PrefabsFolder = "Prefabs";

        private const string ResourceFolder = "/Resources";

        public static string PathToPrefabsJson => Application.dataPath + ResourceFolder + JsonsFolder + PrefabJsonName;
        public static string PrefabFolder => PrefabsFolder;
    }
}