using BepInEx;
using BepInEx.IL2CPP;
using CustomBoostersXp.Script;
using GTFuckingXP.Managers;

namespace CustomBoostersXp
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class BepInExLoader : BasePlugin
    {
        public const string
       MODNAME = "CustomBoosters_XP",
       AUTHOR = "Endskill",
       GUID = AUTHOR + "." + MODNAME,
       VERSION = "1.0.0";

        public override void Load()
        {
            InstanceCache.Instance.SetInstance(new BoosterScriptManager());
        }
    }
}
