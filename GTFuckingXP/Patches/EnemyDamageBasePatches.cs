﻿using GTFuckingXP.Information.Enemies;
using GTFuckingXP.Managers;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using GTFuckingXP.Scripts;
using GTFuckingXP.Extensions;
using Enemies;
using Agents;
using Player;

namespace GTFuckingXP.Patches
{

    [HarmonyBefore(BepInExLoader.GUID, DamageNumbers.Main.GUID)]
    [HarmonyPatch(typeof(Dam_EnemyDamageBase))]
    internal class EnemyDamageBasePatches
    {
        internal static Dictionary<string, Dictionary<int, float>> DamageDistribution;

        [HarmonyPatch(nameof(Dam_EnemyDamageBase.MeleeDamage))]
        [HarmonyPrefix]
        public static void MeleePrefix(Dam_EnemyDamageBase __instance, ref float dam, Agent sourceAgent)
        {
            if (!__instance.Owner.Alive)
                return;

            if (sourceAgent.IsLocallyOwned)
            {
                var damage = dam;
                LogManager.Debug($"Melee damage from local player registered. {damage} was scaled up to:");
                damage *= InstanceCache.Instance.GetActiveLevel().MeleeDamageMultiplier;
                LogManager.Debug($"{damage}");
                dam = damage;
            }
        }

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
                var source = agent.TryCast<PlayerAgent>();
                var enemyXpData = GetEnemyXp(__instance.Owner);
                //For some reason melee damage is consistently halfed ...
                XpDistributionAddDamageDealt(__instance, source, data.damage.Get(__instance.HealthMax)*2);

                if (!__instance.Owner.Alive)
                {
                    
                    if (source.IsLocallyOwned)
                    {

                        GiveXp(__instance.Owner, enemyXpData: enemyXpData);
                    }
                    else
                    {
                        GiveXp(__instance.Owner, enemyXpData, source);
                    }

                    DistributeDamagePercentageXp(__instance, source, enemyXpData);
                }
            }
        }

        [HarmonyBefore(BepInExLoader.GUID, DamageNumbers.Main.GUID)]
        [HarmonyPatch(nameof(Dam_EnemyDamageBase.BulletDamage))]
        [HarmonyPrefix]
        public static void BulletPostfix(Dam_EnemyDamageBase __instance, ref float dam, Agent sourceAgent)
        {
            if (!__instance.Owner.Alive)
                return;

            if (sourceAgent.IsLocallyOwned)
            {
                var damage = dam;
                LogManager.Debug($"Bullet damage from local player registered. {damage} was scaled up to:");
                damage *= InstanceCache.Instance.GetActiveLevel().WeaponDamageMultiplier;
                LogManager.Debug($"{damage}");
                dam = damage;
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
                var source = agent.TryCast<PlayerAgent>();
                var enemyXpData = GetEnemyXp(__instance.Owner);
                XpDistributionAddDamageDealt(__instance, source, data.damage.Get(__instance.HealthMax));

                //Enemy was alive in the postfix but dead now :).
                if (!__instance.Owner.Alive)
                {
                    if (source.IsLocallyOwned)
                    {
                        GiveXp(__instance.Owner, enemyXpData);
                    }
                    else
                    {
                        GiveXp(__instance.Owner, enemyXpData, source);
                    }

                    DistributeDamagePercentageXp(__instance, source, enemyXpData);
                }
            }
        }

        [HarmonyPatch(nameof(Dam_EnemyDamageBase.ReceiveExplosionDamage))]
        [HarmonyPrefix]
        public static void ExplosionPrefix(Dam_EnemyDamageBase __instance, out bool __state)
        {
            __state = __instance.Owner.Alive;
        }

        [HarmonyPatch(nameof(Dam_EnemyDamageBase.ReceiveExplosionDamage))]
        [HarmonyPrefix]
        public static void ExplosionPostfix(Dam_EnemyDamageBase __instance, bool __state, pExplosionDamageData data)
        {
            //Enemy was alive in the postfix but dead now :).
            if (__state && !__instance.Owner.Alive)
            {
                LogManager.Debug("Explosion postfix, Enemy dead");
                GiveXpToEveryone(__instance.Owner, true);
            }
        }

        private static void GiveXp(EnemyAgent killedEnemy, EnemyXp enemyXpData, PlayerAgent sourceAgent = null, bool forceDebuffXp = false)
        {
            var position = killedEnemy.Position;
            position.y = position.y + 1f;
            if (sourceAgent is null)
            {
                if (InstanceCache.Instance.TryGetInstance<XpHandler>(out var xpHandler))
                {
                    xpHandler.AddXp(enemyXpData, position, forceDebuffXp);
                }
            }
            else
            {
                NetworkApiXpManager.SendReceiveXp(sourceAgent, enemyXpData, position, forceDebuffXp);
            }
        }

        private static void GiveXpToEveryone(EnemyAgent killedEnemy, bool forceDebuffXp)
        {
            var enemyXpData = GetEnemyXp(killedEnemy);

            var position = killedEnemy.Position;
            position.y = position.y + 1f;

            if (InstanceCache.Instance.TryGetInstance<XpHandler>(out var xpHandler))
            {
                xpHandler.AddXp(enemyXpData, position, forceDebuffXp);
            }
            NetworkApiXpManager.SendReceiveXpToEveryone(enemyXpData, position, forceDebuffXp);
        }

        private static EnemyXp GetEnemyXp(EnemyAgent killedEnemy)
        {
            var enemyData = InstanceCache.Instance.GetInstance<List<EnemyXp>>();
            var enemyXpData = enemyData.FirstOrDefault(it => it.EnemyId == killedEnemy.EnemyDataID);
            if (enemyXpData is null)
            {
                //No data found, creating a new instance and 
                LogManager.Warn($"There was no enemy XP data found for {killedEnemy.EnemyDataID}!");
                enemyXpData = new EnemyXp(killedEnemy.EnemyDataID, killedEnemy.name, 20000, 10000, 400);
                enemyData.Add(enemyXpData);
                InstanceCache.Instance.SetInstance(enemyData);
            }

            LogManager.Debug($"Enemy kill was registered. Enemy XpData was {enemyXpData.XpGain}.");

            return enemyXpData;
        }

        private static void XpDistributionAddDamageDealt(Dam_EnemyDamageBase hitEnemy, PlayerAgent damageDealer, float damageDealt)
        {
            if (!DamageDistribution.TryGetValue(hitEnemy.Owner.name, out var playerDamages))
            {
                LogManager.Debug("Enemy not known, generating new entry");
                playerDamages = new Dictionary<int, float>();
                DamageDistribution[hitEnemy.Owner.name] = playerDamages;
            }

            if(!playerDamages.ContainsKey(damageDealer.PlayerSlotIndex))
            {
                playerDamages.Add(damageDealer.PlayerSlotIndex, damageDealt);
            }
            else
            {
                LogManager.Debug($"damage score before += was {playerDamages[damageDealer.PlayerSlotIndex]}");
                playerDamages[damageDealer.PlayerSlotIndex] += damageDealt;
                LogManager.Debug($"Now is {playerDamages[damageDealer.PlayerSlotIndex]}");
            }
        }

        private static void DistributeDamagePercentageXp(Dam_EnemyDamageBase killedEnemy, Agent lastHit, EnemyXp enemyXpData)
        {
            if (DamageDistribution.ContainsKey(killedEnemy.Owner.name))
            {
                foreach (var playerToDamageDealt in DamageDistribution[killedEnemy.Owner.name])
                {
                    foreach (var player in PlayerManager.PlayerAgentsInLevel)
                    {
                        if (player.name != lastHit.name)
                        {
                            if (player.PlayerSlotIndex == playerToDamageDealt.Key)
                            {
                                var percentageDealt = playerToDamageDealt.Value / killedEnemy.HealthMax;
                                var xpPercentage = (uint)(enemyXpData.XpGain * percentageDealt);

                                LogManager.Debug($"Found damage distribution of {player.name} having done {playerToDamageDealt.Value} damage ({percentageDealt}%)" +
                                    $"\n xpGain is {(uint)(enemyXpData.XpGain * percentageDealt)}");

                                NetworkApiXpManager.SendStaticXpInfo(player, (uint)(enemyXpData.XpGain * percentageDealt),
                                    (uint)(enemyXpData.DebuffXp * percentageDealt), (int)(enemyXpData.LevelScalingXpDecrese * percentageDealt));
                            }
                        }
                    }
                }

                DamageDistribution.Remove(killedEnemy.Owner.name);
            }
        }
    }
}
