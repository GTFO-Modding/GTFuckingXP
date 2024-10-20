using GTFuckingXP.Extensions;
using GTFuckingXP.Information.Level;
using HarmonyLib;
using Player;

namespace GTFuckingXP.Patches
{
    [HarmonyPatch(typeof(SentryGunInstance_Firing_Bullets))]
    internal static class SentryGunFiringPatches
    {
        [HarmonyPatch(nameof(SentryGunInstance_Firing_Bullets.UpdateAmmo))]
        [HarmonyPrefix]
        private static void PrefixSentryAmmo(SentryGunInstance_Firing_Bullets __instance)
        {
            PlayerAgent owner = __instance.m_core.Owner;
            Level level;
            if (owner.IsLocallyOwned)
                level = CacheApiWrapper.GetActiveLevel();
            else if (!CacheApiWrapper.GetPlayerToLevelMapping().TryGetValue(owner.PlayerSlotIndex, out level!))
                return;

            CustomScalingBuff? buff = level.CustomScaling.FirstOrDefault(buff => buff.CustomBuff == Enums.CustomScaling.ToolEfficiency);
            if (buff == null) return;

            var core = __instance.m_core.Cast<SentryGunInstance>();
            // Cost of bullet updates every update before UpdateAmmo so don't need to worry about double calcs.
            // Apparently correctly modifies ammo shown on deployed sentry screen??? I have no idea how.
            core.CostOfBullet /= buff.Value;
        }
    }
}
