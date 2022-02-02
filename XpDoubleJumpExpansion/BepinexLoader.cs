using BepInEx;
using BepInEx.IL2CPP;
using EndskApi.Api;
using XpDoubleJumpExpansion.Manager;

namespace XpDoubleJumpExpansion
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    [BepInDependency("Endskill.GTFuckingXP", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("com.mccad00.DoubleJump", BepInDependency.DependencyFlags.HardDependency)]
    public class BepinexLoader : BasePlugin
    {
        public const string
            MODNAME = "Xp_DoubleJumpExpansion",
            AUTHOR = "Endskill",
            GUID = AUTHOR + "." + MODNAME,
            VERSION = "1.0.0";

        public override void Load()
        {
            LogManager._debugMessagesActive = Config.Bind("Dev Settings", "DebugMessages", false, "This settings activates/deactivates debug messages in the console for this specific plugin.").Value;
            LogManager.SetLogger(Log);
            CacheApi.SaveInstance(new DoubleJumpExpansionManager(), DoubleJumpExpansionManager.CacheString);
        }
    }
}
