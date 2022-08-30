using AtLib.AtSound;
using BepInEx.Logging;
using HarmonyLib;
using Il2CppSystem.IO;
using UnityEngine;
using UnityEngine.Events;

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
    
    [HarmonyPatch(typeof(AtSoundManager), nameof(AtSoundManager.LoadPack), typeof(string), typeof(bool), typeof(UnityAction))]
    [HarmonyPrefix]
    private static void LoadPack(ref string name, bool readStream, UnityAction completeMethod)
    {
        string moddedAudio = "mods/" + name;
        if (File.Exists(Application.streamingAssetsPath + "/" + moddedAudio + ".awb") && File.Exists(Application.streamingAssetsPath + "/" + moddedAudio + ".acb")) name = moddedAudio;
        if (Plugin.Instance.verboseMode.Value) LogFile("/" + name);
    }
    
    private static void LogFile(string path) => _fileLog.LogInfo(path.Replace(Application.streamingAssetsPath, ""));

    private static string ModFile(string path)
    {
        string modPath = path.Replace("/SOUL HACKERS2_Data/StreamingAssets/", "/SOUL HACKERS2_Data/StreamingAssets/mods/");
        if (File.Exists(modPath)) path = modPath;
        return path;
    }
}
