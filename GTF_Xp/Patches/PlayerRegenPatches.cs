using GTFuckingXP.Extensions;
using HarmonyLib;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Enums;
using Player;

namespace GTFuckingXp.Patches
{
    [HarmonyPatch(typeof(Dam_PlayerDamageBase))]
    internal static class PlayerRegenPatches
    {
        [HarmonyPatch(nameof(Dam_PlayerDamageBase.OnIncomingDamage))]
        [HarmonyPostfix]
        private static void Postfix_OnDamage(Dam_PlayerDamageBase __instance)
        {
            PlayerAgent player = __instance.Owner;
            Level? level;
            if (player.IsLocallyOwned)
                level = CacheApiWrapper.GetActiveLevel();
            else if (!CacheApiWrapper.GetPlayerToLevelMapping().TryGetValue(player.PlayerSlotIndex, out level))
                return;

            CustomScalingBuff? buff = level.CustomScaling.FirstOrDefault(buff => buff.CustomBuff == CustomScaling.RegenStartDelayMultiplier);
            if (buff != null)
                __instance.m_nextRegen = Clock.Time + player.PlayerData.healthRegenStartDelayAfterDamage * buff.Value;
        }
    }
}
