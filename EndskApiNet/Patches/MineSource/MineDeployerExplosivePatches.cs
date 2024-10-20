using HarmonyLib;
using Player;

namespace EndskApi.Patches.MineSource
{
    [HarmonyPatch(typeof(MineDeployerInstance_Detonate_Explosive))]
    internal static class MineDeployerExplosivePatches
    {
        public static PlayerAgent? CachedAgent { get; private set; } = null;

        // Since this only runs on host, enemies hit will run ReceiveExplosionDamage before postfix runs.
        [HarmonyPatch(nameof(MineDeployerInstance_Detonate_Explosive.DoExplode))]
        [HarmonyPrefix]
        public static void ExplodePrefix(MineDeployerInstance_Detonate_Explosive __instance)
        {
            CachedAgent = __instance.m_core.Owner;
        }

        [HarmonyPatch(nameof(MineDeployerInstance_Detonate_Explosive.DoExplode))]
        [HarmonyPostfix]
        public static void ExplodePostfix()
        {
            CachedAgent = null;
        }
    }
}
