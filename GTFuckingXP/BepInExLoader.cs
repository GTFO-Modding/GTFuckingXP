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
    [BepInDependency("dev.gtfomodding.gtfo-api", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("com.dak.DamageNumbers", BepInDependency.DependencyFlags.HardDependency)]
    public class BepInExLoader : BasePlugin
    {
        public const string
        MODNAME = "GTFuckingXP",
        AUTHOR = "Endskill",
        GUID = AUTHOR + "." + MODNAME,
        VERSION = "1.0.0";

        public static ConfigEntry<bool> RundownDevMode { get; private set; }
        public static ConfigEntry<bool> DebugMessages { get; private set; }

        public override void Load()
        {
            RundownDevMode = Config.Bind("Dev Settings", "RundownDev Mode", false, "!WIP! !This setting opens up a communication way for the external GTFuckingXP Dev tools.\nThis will allow as an example hot realoading while in a Level.");
            DebugMessages = Config.Bind("Dev Settings", "DebugMessages", false, "This settings activates/deactivates debug messages in the console for this specific plugin.");

            ClassInjector.RegisterTypeInIl2Cpp<XpHandler>();
            ClassInjector.RegisterTypeInIl2Cpp<XpBar>();

            InstanceCache.Instance = new InstanceCache();
            ScriptManager.Instance = new ScriptManager();
            NetworkApiXpManager.Setup();

            new Harmony(GUID).PatchAll();
        }
    }
}
