using CellMenu;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTFuckingXP.Patches.SelectLevelPatches
{
    [HarmonyPatch(typeof(CM_PageLoadout))]
    public class PageLoadoutPatches
    {
        [HarmonyPatch(nameof(CM_PageLoadout.Setup))]
        [HarmonyPostfix]
        public static void SetupPostfix(CM_PageLoadout __instance)
        {

        }
    }
}
