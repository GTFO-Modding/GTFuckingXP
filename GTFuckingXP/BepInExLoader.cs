using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using GTFuckingXP.Managers;
using GTFuckingXP.Scripts;
using HarmonyLib;
using UnhollowerRuntimeLib;

namespace GTFuckingXP
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class BepInExLoader : BasePlugin
    {
        public const string
        MODNAME = "GTFuckingXP",
        AUTHOR = "Endskill",
        GUID = AUTHOR + "." + MODNAME,
        VERSION = "1.0.0";

        public static ConfigEntry<bool> RundownDevMode { get; private set; }

        public override void Load()
        {
            RundownDevMode = Config.Bind("RundownDev Settings", "RundownDev Mode", false, "!WIP! !This setting opens up a communication way for the external GTFuckingXP Dev tools.\nThis will allow as an example hot realoading while in a Level.");

            ClassInjector.RegisterTypeInIl2Cpp<XpHandler>();

            InstanceCache.Instance = new InstanceCache();
            ScriptManager.Instance = new ScriptManager();

            new Harmony(GUID).PatchAll();
        }
    }
}
