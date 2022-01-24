using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;

namespace EndskApi
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class BepInExLoader : BasePlugin
    {
        public const string
       MODNAME = "EndskApi",
       AUTHOR = "Endskill",
       GUID = AUTHOR + "." + MODNAME,
       VERSION = "1.0.0";

        public static Harmony Harmony { get; private set; }

        public override void Load()
        {
            Harmony = new Harmony(GUID);
        }
    }
}
