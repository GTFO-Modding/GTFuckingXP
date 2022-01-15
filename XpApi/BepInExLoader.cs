using BepInEx;
using BepInEx.IL2CPP;

namespace XpApi
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    [BepInDependency(GTFuckingXP.BepInExLoader.GUID, BepInDependency.DependencyFlags.HardDependency)]
    public class BepInExLoader : BasePlugin
    {
        public const string
        MODNAME = "XpApi",
        AUTHOR = "Endskill",
        GUID = AUTHOR + "." + MODNAME,
        VERSION = "1.0.0";

        public override void Load()
        {
        }
    }
}
