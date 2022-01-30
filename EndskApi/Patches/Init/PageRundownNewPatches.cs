using CellMenu;
using EndskApi.Api;
using HarmonyLib;

namespace EndskApi.Patches.Init
{
    [HarmonyPatch(typeof(CM_PageRundown_New))]
    internal class PageRundownNewPatches
    {
        [HarmonyPatch(nameof(CM_PageRundown_New.PlaceRundown))]
        [HarmonyPostfix]
        public static void PlaceRundownPostFix()
        {
            InitApi.InvokeInitCallbacks();
        }
    }
}
