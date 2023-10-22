using Agents;
using GTFuckingXP;
using GTFuckingXP.Extensions;
using GTFuckingXP.Managers;
using HarmonyLib;

namespace GTFuckingXp.Patches
{
    [HarmonyPatch(typeof(Dam_EnemyDamageBase))]
    public static class EnemyDamageBasePatches
    {

        [HarmonyPatch(nameof(Dam_EnemyDamageBase.MeleeDamage))]
        [HarmonyPrefix]
        public static void MeleePrefix(Dam_EnemyDamageBase __instance, ref float dam, Agent sourceAgent)
        {
            if (!__instance.Owner.Alive)
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

        [HarmonyBefore(BepInExLoader.GUID, "com.dak.DamageNumbers")]
        [HarmonyPatch(nameof(Dam_EnemyDamageBase.BulletDamage))]
        [HarmonyPrefix]
        public static void BulletPostfix(Dam_EnemyDamageBase __instance, ref float dam, Agent sourceAgent)
        {
            if (!__instance.Owner.Alive)
                return;

            if (sourceAgent != null)
            {
                if (sourceAgent.IsLocallyOwned)
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
