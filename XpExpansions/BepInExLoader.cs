using BepInEx;
using BepInEx.IL2CPP;
using EndskApi.Api;
using XpExpansions.Extensions;
using XpExpansions.Manager;

namespace XpExpansions
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    [BepInDependency(GTFuckingXP.BepInExLoader.GUID, BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency(EndskApi.BepInExLoader.GUID, BepInDependency.DependencyFlags.HardDependency)]
    public class BepinExLoader : BasePlugin
    {
        public const string
        MODNAME = "XpExpansions",
        AUTHOR = "Endskill",
        GUID = AUTHOR + "." + MODNAME,
        VERSION = "1.0.0";

        public override void Load()
        {
            CacheApi.SaveInstance(new ExpansionManager(), CacheApiWrapper.ExtensionCacheName);
        }
    }
}
