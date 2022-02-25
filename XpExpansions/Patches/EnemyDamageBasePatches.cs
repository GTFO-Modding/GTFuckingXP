using Agents;
using HarmonyLib;

namespace XpExpansions.Patches
{
    [HarmonyBefore(BepinExLoader.GUID, GTFuckingXP.BepInExLoader.GUID)]
    [HarmonyPatch(typeof(Dam_EnemyDamageBase))]
    public class EnemyDamageBasePatches
    {
        [HarmonyPatch(nameof(Dam_EnemyDamageBase.MeleeDamage))]
        [HarmonyPrefix]
        public static bool MeleePrefix(Dam_EnemyDamageBase __instance, ref float dam, Agent sourceAgent)
        {
            //TODO 
            return true;
        }
    }
}
