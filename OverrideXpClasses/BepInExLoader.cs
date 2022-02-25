using BepInEx;
using BepInEx.IL2CPP;
using EndskApi.Api;
using System;

namespace OverrideXpClasses
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    [BepInDependency(GTFuckingXP.BepInExLoader.GUID, BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency(EndskApi.BepInExLoader.GUID, BepInDependency.DependencyFlags.HardDependency)]
    public class BepinExLoader : BasePlugin
    {
        public const string
        MODNAME = "OverrideXpClasses",
        AUTHOR = "Endskill",
        GUID = AUTHOR + "." + MODNAME,
        VERSION = "1.0.0";

        public override void Load()
        {
            LogManager.SetLogger(Log);

            CacheApi.SaveInstance(new OverrideClassesManager(), GTFuckingXP.Extensions.CacheApiWrapper.XpModCacheName);
        }
    }
}
