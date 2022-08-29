using BepInEx.Logging;
using HarmonyLib;
using Il2CppSystem.IO;
using UnityEngine;

namespace SoulHackers2ModLoader;

[HarmonyPatch]
internal class ModLoader
{
    private static readonly ManualLogSource _fileLog = BepInEx.Logging.Logger.CreateLogSource("FileLog");

    [HarmonyPatch(typeof(AssetBundle), nameof(AssetBundle.LoadFromFile), typeof(string))]
    [HarmonyPrefix]
    private static void LoadFromFile(ref string path)
    {
        path = ModFile(path);
        if (Plugin.Instance.verboseMode.Value) LogFile(path);
    }

    [HarmonyPatch(typeof(AssetBundle), nameof(AssetBundle.LoadFromFileAsync), typeof(string))]
    [HarmonyPrefix]
    private static void LoadFromFileAsync(ref string path)
    {
        path = ModFile(path);
        if (Plugin.Instance.verboseMode.Value) LogFile(path);
    }

    private static void LogFile(string path) => _fileLog.LogInfo(path.Replace(Application.streamingAssetsPath, ""));

    private static string ModFile(string path)
    {
        string modPath = path.Replace("/SOUL HACKERS2_Data/StreamingAssets/", "/mods/");
        if (File.Exists(modPath)) path = modPath;
        return path;
    }
}
