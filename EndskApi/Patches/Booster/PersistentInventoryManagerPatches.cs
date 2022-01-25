using HarmonyLib;
using Il2CppSystem.Collections.Generic;

namespace EndskApi.Patches.Booster
{
    [HarmonyPatch(typeof(PersistentInventoryManager))]
    public class PersistentInventoryManagerPatches
    {
        [HarmonyPatch(nameof(PersistentInventoryManager.GetBoosterImplantInventory))]
        public static bool GetBoosterImplamtInventoryPrefix(List<BoosterImplantInventoryItem> __result, 
            BoosterImplantCategory category)
        {


            return false;
        }
    }
}
