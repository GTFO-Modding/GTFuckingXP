using CellMenu;
using CustomBoostersXp.Script;
using GTFuckingXP.Managers;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBoostersXp.Patches
{
    [HarmonyPatch(typeof(CM_PageRundown_New))]
    public class PageRundownNewPatches
    {
        [HarmonyPatch(nameof(CM_PageRundown_New.PlaceRundown))]
        [HarmonyPostfix]
        public static void PlaceRundownPostFix()
        {
            InstanceCache.Instance.GetInstance<BoosterScriptManager>().Initialize();
        }
    }

    [HarmonyPatch(typeof(GuiManager))]
    public class GUIManagerPatches
    {
        [HarmonyPatch(nameof(GuiManager.Setup))]
        [HarmonyPrefix]
        public static void SetupPrefix()
        {
            InstanceCache.Instance.GetInstance<BoosterScriptManager>().Initialize();
        }
    }
}
