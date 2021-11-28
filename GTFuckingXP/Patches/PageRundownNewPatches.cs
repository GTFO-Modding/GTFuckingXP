using CellMenu;
using GTFuckingXP.Managers;
using HarmonyLib;

namespace GTFuckingXP.Patches
{
    [HarmonyPatch(typeof(CM_PageRundown_New))]
    public class PageRundownNewPatches
    {
        [HarmonyPatch(nameof(CM_PageRundown_New.PlaceRundown))]
        [HarmonyPostfix]
        public static void PlaceRundownPostFix()
        {
            ScriptManager.Instance.Initialize();
        }
    }
}
