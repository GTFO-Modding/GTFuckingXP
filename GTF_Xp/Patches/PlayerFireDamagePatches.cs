using GTFuckingXP.Extensions;
using HarmonyLib;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Enums;
using Agents;

namespace GTFuckingXp.Patches
{
    [HarmonyPatch(typeof(Dam_SyncedDamageBase))]
    internal static class PlayerFireDamagePatches
    {
        // Dam_PlayerDamageBase does not override FireDamage
        // Assuming that only players will be damaged by this since it's unused in other mods/vanilla AFAIK
        [HarmonyPatch(nameof(Dam_SyncedDamageBase.FireDamage))]
        [HarmonyPrefix]
        private static void Prefix_FireDamage(ref float dam, Agent sourceAgent)
        {
            if (sourceAgent == null || !sourceAgent.Alive || !sourceAgent.IsLocallyOwned || sourceAgent.Type != AgentType.Player) return;

            CustomScalingBuff? buff = CacheApiWrapper.GetActiveLevel().CustomScaling.FirstOrDefault(buff => buff.CustomBuff == CustomScaling.BleedResistance);
            if (buff != null)
                dam *= 2f - buff.Value;
        }
    }
}
