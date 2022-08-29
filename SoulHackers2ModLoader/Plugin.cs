using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Il2CppSystem.IO;
using UnityEngine;

namespace SoulHackers2ModLoader;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInProcess("SOUL HACKERS2.exe")]
public class Plugin : BasePlugin
{
    public static Plugin Instance { get; private set; }
    public new static ManualLogSource Log { get; private set; }
    public ConfigEntry<bool> verboseMode { get; set; }
    public override void Load()
    {

        Instance = this;
        Log = base.Log;

        Log.LogInfo($"{MyPluginInfo.PLUGIN_NAME} is loaded!");
        string modsPath = Application.dataPath.Replace("/SOUL HACKERS2_Data", "/mods");
        if (!Directory.Exists(modsPath)) 
        {
            Directory.CreateDirectory(modsPath);
            Log.LogWarning("Mods folder didn't exist. Created one!");
        }

        InitConfig();

        var harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        harmony.PatchAll();
    }

    private void InitConfig()
    {
        Config.SaveOnConfigSet = true;

        verboseMode = Config.Bind(
            "Debug",
            "Verbose Mode",
            false,
            "Prints out the path to what file is currently being loaded");
    }
}