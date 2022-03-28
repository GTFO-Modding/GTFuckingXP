using EndskApi.Api;
using EndskApi.Enums.EnemyKill;
using EndskApi.Information.EnemyKill;
using Enemies;
using HarmonyLib;
using Player;
using SNetwork;
using System.Collections.Generic;

namespace EndskApi.Patches.EnemyKill
{
    [HarmonyBefore(BepInExLoader.GUID, "com.dak.DamageNumbers")]
    [HarmonyPatch(typeof(Dam_EnemyDamageBase))]
    internal class EnemyDamageBasePatches
    {
        [HarmonyPatch(nameof(Dam_EnemyDamageBase.ReceiveMeleeDamage))]
        [HarmonyPrefix]
        public static void MeleePrefix(Dam_EnemyDamageBase __instance, out bool __state)
        {
            __state = __instance.Owner.Alive;
        }

        [HarmonyPatch(nameof(Dam_EnemyDamageBase.ReceiveMeleeDamage))]
        [HarmonyPostfix]
        public static void MeleePostfix(Dam_EnemyDamageBase __instance, bool __state, pFullDamageData data)
        {
            if (__state)
            {
                data.source.TryGet(out var agent);
                if (agent is null)
                {
                    return;
                }
                var source = agent.TryCast<PlayerAgent>();
                DamageDistributionAddDamageDealt(__instance.Owner, source, data.damage.Get(__instance.HealthMax));

                if (!__instance.Owner.Alive)
                {
                    EnemyDied(__instance.Owner, source, LastHitType.Melee);
                }
            }
        }

        [HarmonyPatch(nameof(Dam_EnemyDamageBase.ReceiveBulletDamage))]
        [HarmonyPrefix]
        public static void BulletPrefix(Dam_EnemyDamageBase __instance, out bool __state)
        {
            __state = __instance.Owner.Alive;
        }

        [HarmonyPatch(nameof(Dam_EnemyDamageBase.ReceiveBulletDamage))]
        [HarmonyPostfix]
        public static void BulletPostfix(Dam_EnemyDamageBase __instance, bool __state, pBulletDamageData data)
        {
            if (__state)
            {
                data.source.TryGet(out var agent);
                if (agent is null)
                {
                    return;
                }
                var source = agent.TryCast<PlayerAgent>();
                DamageDistributionAddDamageDealt(__instance.Owner, source, data.damage.Get(__instance.HealthMax));

                if(!__instance.Owner.Alive)
                {
                    EnemyDied(__instance.Owner, source, LastHitType.ShootyWeapon);
                }
            }
        }

        [HarmonyPatch(nameof(Dam_EnemyDamageBase.ExplosionDamage))]
        [HarmonyPrefix]
        public static void ExplosionPrefix(Dam_EnemyDamageBase __instance, out bool __state)
        {
            __state = __instance.Owner.Alive && SNet.IsMaster;
        }

        [HarmonyPatch(nameof(Dam_EnemyDamageBase.ExplosionDamage))]
        [HarmonyPostfix]
        public static void ExplosionPostfix(Dam_EnemyDamageBase __instance, bool __state)
        {
            //There is no good way to get the playeragent, that placed this mine.
            if (__state && !__instance.Owner.Alive)
            {
                EnemyDied(__instance.Owner, null, LastHitType.Explosion);
            }
        }

        private static void DamageDistributionAddDamageDealt(EnemyAgent hitEnemy, PlayerAgent damageDealer, float damageDealt)
        {
            var damageDistribution = CacheApi.GetInstance<Dictionary<string, EnemyKillDistribution>>(CacheApi.InternalCache);

            if (!damageDistribution.ContainsKey(hitEnemy.name))
            {
                var distribution = new EnemyKillDistribution(hitEnemy);
                distribution.AddDamageDealtByPlayerAgent(damageDealer, damageDealt);
                damageDistribution[hitEnemy.name] = distribution;
                return;
            }

            damageDistribution[hitEnemy.name].AddDamageDealtByPlayerAgent(damageDealer, damageDealt);
        }

        private static void EnemyDied(EnemyAgent hitEnemy, PlayerAgent lastHit, LastHitType lastHitType)
        {
            var damageDistribution = CacheApi.GetInstance<Dictionary<string, EnemyKillDistribution>>(CacheApi.InternalCache);
            if(damageDistribution.TryGetValue(hitEnemy.name, out EnemyKillDistribution distribution))
            {
                distribution.LastHitDealtBy = lastHit;
                distribution.lastHitType = lastHitType;
                
                EnemyKillApi.InvokeEnemyKilledCallbacks(distribution);
            }
        }
    }
}
