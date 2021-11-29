using GTFuckingXP.Information.Enemies;
using GTFuckingXP.Managers;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using GTFuckingXP.Scripts;
using Player;
using Agents;
using GTFuckingXP.Extensions;
using Enemies;

namespace GTFuckingXP.Patches
{

    [HarmonyPatch(typeof(Dam_EnemyDamageBase))]
    internal class EnemyDamageBasePatches 
    {
        //[HarmonyPatch(nameof(Dam_EnemyDamageBase.ProcessReceivedDamage))]
        //[HarmonyPrefix]
        //public static void Prefix(Dam_EnemyDamageBase __instance, ref float damage, Agent damageSource)
        //{
        //    if (!damageSource.IsLocallyOwned)
        //        return;

        //    if(__instance.WillDamageKill(damage))
        //    {
        //        var instanceCache = InstanceCache.Instance;
        //        var enemyData = instanceCache.GetInstance<List<EnemyXp>>();
        //        var enemyXpData = enemyData.FirstOrDefault(it => it.EnemyId == __instance.Owner.EnemyDataID);
        //        if(enemyXpData is null)
        //        {
        //            //No data found, creating a new instance and 
        //            LogManager.Warn($"There was no Enemy XP data found for {__instance.Owner.EnemyDataID}!");
        //            enemyXpData = new EnemyXp(__instance.Owner.EnemyDataID, 20000, 10000, 400);
        //            enemyData.Add(enemyXpData);
        //            instanceCache.SetInstance(enemyData);
        //        }

        //        LogManager.Debug($"Enemy kill was registered. Enemy XpData was {enemyXpData.XpGain}.");

        //        if(instanceCache.TryGetinstance<XpHandler>(out var xpHandler))
        //        {
        //            xpHandler.AddXp(enemyXpData);
        //        }
        //    }
        //}

        [HarmonyPatch(nameof(Dam_EnemyDamageBase.ReceiveMeleeDamage))]
        [HarmonyPrefix]
        public static void MeleePrefix(Dam_EnemyDamageBase __instance, pFullDamageData data)
        {
            if (!__instance.Owner.Alive)
                return;

            data.source.TryGet(out var agent);

            if(agent.IsLocallyOwned)
            {
                var damage = data.damage.Get(float.MaxValue);
                LogManager.Debug($"Melee damage from local player registered. {damage} was scaled up to:");
                damage *= InstanceCache.Instance.GetActiveLevel().WeaponDamageMultiplier;
                LogManager.Debug($"{damage}");
                data.damage.Set(damage, float.MaxValue);
            }
        }

        [HarmonyPatch(nameof(Dam_EnemyDamageBase.ReceiveMeleeDamage))]
        [HarmonyPrefix]
        public static void MeleePostfix(Dam_EnemyDamageBase __instance, pFullDamageData data)
        {
            data.source.TryGet(out var agent);

            if (agent.IsLocallyOwned)
            {
                if (__instance.Owner.Alive)
                {
                    GiveXp(__instance.Owner);
                }
            }
        }

        [HarmonyPatch(nameof(Dam_EnemyDamageBase.ReceiveBulletDamage))]
        [HarmonyPrefix]
        public static void BulletPrefix(Dam_EnemyDamageBase __instance, pBulletDamageData data)
        {
            if (!__instance.Owner.Alive)
                return;

            data.source.TryGet(out var agent);

            if (agent.IsLocallyOwned)
            {
                var damage = data.damage.Get(float.MaxValue);
                LogManager.Debug($"Bullet damage from local player registered. {damage} was scaled up to:");
                damage *= InstanceCache.Instance.GetActiveLevel().WeaponDamageMultiplier;
                LogManager.Debug($"{damage}");
                data.damage.Set(damage, float.MaxValue);
            }
        }

        [HarmonyPatch(nameof(Dam_EnemyDamageBase.ReceiveBulletDamage))]
        [HarmonyPostfix]
        public static void BulletPostfix(Dam_EnemyDamageBase __instance, pBulletDamageData data)
        {
            data.source.TryGet(out var agent);

            if (agent.IsLocallyOwned)
            {
                if (__instance.Owner.Alive)
                {
                    GiveXp(__instance.Owner);
                }
            }
        }

        private static void GiveXp(EnemyAgent killedEnemy)
        {
            var instanceCache = InstanceCache.Instance;
            var enemyData = instanceCache.GetInstance<List<EnemyXp>>();
            var enemyXpData = enemyData.FirstOrDefault(it => it.EnemyId == killedEnemy.EnemyDataID);
            if (enemyXpData is null)
            {
                //No data found, creating a new instance and 
                LogManager.Warn($"There was no Enemy XP data found for {killedEnemy.EnemyDataID}!");
                enemyXpData = new EnemyXp(killedEnemy.EnemyDataID, killedEnemy.name, 20000, 10000, 400);
                enemyData.Add(enemyXpData);
                instanceCache.SetInstance(enemyData);
            }

            LogManager.Debug($"Enemy kill was registered. Enemy XpData was {enemyXpData.XpGain}.");

            if (instanceCache.TryGetinstance<XpHandler>(out var xpHandler))
            {
                xpHandler.AddXp(enemyXpData);
            }
        }
    }
}
