using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using EndskApi.Manager;
using EndskApi.Scripts;
using HarmonyLib;
using Il2CppInterop.Runtime.Injection;

namespace EndskApi
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class BepInExLoader : BasePlugin
    {
        public const string
       MODNAME = "EndskApi",
       AUTHOR = "Endskill",
       GUID = AUTHOR + "." + MODNAME,
       VERSION = "1.0.1";

        public static Harmony Harmony { get; private set; }
        public static ConfigFile ConfigLoader { get; private set; }
        public override void Load()
        {
            LogManager.SetLogger(Log);
            LogManager._debugMessagesActive = Config.Bind("Dev Settings", "DebugMessages", false, "This settings activates/deactivates debug messages in the console for this specific plugin.").Value;

            ConfigLoader = Config;
            ClassInjector.RegisterTypeInIl2Cpp<BaseMenu>();
            ClassInjector.RegisterTypeInIl2Cpp<MainMenu>();

            Harmony = new Harmony(GUID);
        }
    }
}
