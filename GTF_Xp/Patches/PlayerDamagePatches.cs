using GTFuckingXP.Extensions;
using HarmonyLib;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Enums;
using Agents;
using Player;
using GTFuckingXP.Managers;

namespace GTFuckingXp.Patches
{
    [HarmonyPatch]
    internal static class PlayerDamagePatches
    {
        [HarmonyPatch(typeof(Dam_PlayerDamageLimb), nameof(Dam_PlayerDamageLimb.BulletDamage))]
        [HarmonyPrefix]
        private static void Prefix_BulletDamage(Dam_PlayerDamageLimb __instance, ref float dam, Agent sourceAgent)
        {
            if (!__instance.m_base.Owner.Alive)
                return;

            if (sourceAgent != null)
            {
                if (sourceAgent.IsLocallyOwned && !SentryGunCheckPatches.SentryShot)
                {
                    var damage = dam;
                    LogManager.Debug($"Bullet damage from local player registered. {damage} was scaled up to:");
                    damage *= CacheApiWrapper.GetActiveLevel().WeaponDamageMultiplier;
                    LogManager.Debug($"{damage}");
                    dam = damage;
                }
            }
        }

        // Dam_PlayerDamageBase does not override FireDamage
        [HarmonyPatch(typeof(Dam_SyncedDamageBase), nameof(Dam_SyncedDamageBase.FireDamage))]
        [HarmonyPrefix]
        private static void Prefix_FireDamage(Dam_SyncedDamageBase __instance, ref float dam, Agent sourceAgent)
        {
            if (__instance.DamageBaseOwner != DamageBaseOwnerType.Player) return;
            PlayerAgent player = __instance.GetBaseAgent().Cast<PlayerAgent>();

            if (!player.Alive || !player.IsLocallyOwned) return;

            CustomScalingBuff? buff = CacheApiWrapper.GetActiveLevel().CustomScaling.FirstOrDefault(buff => buff.CustomBuff == CustomScaling.BleedResistance);
            if (buff != null)
                dam *= 2f - buff.Value;
        }

        // Dam_PlayerDamageBase does not override ExplosionDamage
        [HarmonyPatch(typeof(Dam_SyncedDamageBase), nameof(Dam_SyncedDamageBase.ExplosionDamage))]
        [HarmonyPrefix]
        private static void Prefix_ExplosionDamage(Dam_SyncedDamageBase __instance, ref float dam)
        {
            if (__instance.DamageBaseOwner != DamageBaseOwnerType.Player) return;
            PlayerAgent player = __instance.GetBaseAgent().Cast<PlayerAgent>();
            Level level;
            if (player.IsLocallyOwned)
                level = CacheApiWrapper.GetActiveLevel();
            else if (!CacheApiWrapper.GetPlayerToLevelMapping().TryGetValue(player.PlayerSlotIndex, out level!))
                return;

            CustomScalingBuff? buff = level.CustomScaling.FirstOrDefault(buff => buff.CustomBuff == CustomScaling.ExplosionResistance);
            if (buff != null)
                dam *= 2f - buff.Value;
        }
    }
}
