using Agents;
using GTFuckingXP;
using GTFuckingXP.Extensions;
using GTFuckingXP.Managers;
using HarmonyLib;

namespace GTFuckingXp.Patches
{
    [HarmonyPatch(typeof(Dam_EnemyDamageLimb))]
    public static class EnemyDamageLimbPatches
    {

        [HarmonyPatch(nameof(Dam_EnemyDamageLimb.MeleeDamage))]
        [HarmonyPrefix]
        public static void MeleePrefix(Dam_EnemyDamageLimb __instance, ref float dam, Agent sourceAgent)
        {
            if (!__instance.m_base.Owner.Alive)
                return;

            if (sourceAgent != null)
            {
                if (sourceAgent.IsLocallyOwned)
                {
                    var damage = dam;
                    LogManager.Debug($"Melee damage from local player registered. {damage} was scaled up to:");
                    damage *= CacheApiWrapper.GetActiveLevel().MeleeDamageMultiplier;
                    LogManager.Debug($"{damage}");
                    dam = damage;
                }
            }
        }

        [HarmonyPatch(nameof(Dam_EnemyDamageLimb.BulletDamage))]
        [HarmonyPrefix]
        public static void BulletPostfix(Dam_EnemyDamageLimb __instance, ref float dam, Agent sourceAgent)
        {
            if (!__instance.m_base.Owner.Alive)
                return;

            if (sourceAgent != null)
            {
                if (sourceAgent.IsLocallyOwned && !SentryGunCheckPatches.SentryShot)
                {
                    var damage = dam;
                    LogManager.Debug($"Bullet damage from local player registered. {damage} was scaled to:");
                    damage *= CacheApiWrapper.GetActiveLevel().WeaponDamageMultiplier;
                    LogManager.Debug($"{damage}");
                    dam = damage;
                }
            }
        }
    }
}
