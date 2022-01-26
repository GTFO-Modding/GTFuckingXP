using CellMenu;
using CustomBoostersXp.Manager;
using EndskApi.Api;
using HarmonyLib;

namespace CustomBoostersXp.Patches
{
    [HarmonyBefore(GTFuckingXP.BepInExLoader.GUID, BepInExLoader.GUID)]
    [HarmonyPatch(typeof(CM_PageRundown_New))]
    public class PageRundownNewPatches
    {
        [HarmonyPatch(nameof(CM_PageRundown_New.PlaceRundown))]
        [HarmonyPostfix]
        public static void PlaceRundownPostFix()
        {
            CacheApi.GetInstance<BoosterScriptManager>().Initialize();
        }
    }

    [HarmonyBefore(GTFuckingXP.BepInExLoader.GUID, BepInExLoader.GUID)]
    [HarmonyPatch(typeof(GuiManager))]
    public class GUIManagerPatches
    {
        [HarmonyPatch(nameof(GuiManager.Setup))]
        [HarmonyPrefix]
        public static void SetupPrefix()
        {
            CacheApi.GetInstance<BoosterScriptManager>().Initialize();
        }
    }
}
