using GTFuckingXP.Information.Enemies;
using GTFuckingXP.Managers;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using GTFuckingXP.Scripts;
using GTFuckingXP.Extensions;
using Enemies;
using Agents;
using Player;
using System.Threading.Tasks;

namespace GTFuckingXP.Patches
{

    [HarmonyPatch(typeof(Dam_EnemyDamageBase))]
    internal class EnemyDamageBasePatches
    {
        private readonly static object _lockObject = new object();

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
        [HarmonyPostfix]
        public static void MeleePostfix(Dam_EnemyDamageBase __instance, pFullDamageData data)
        {
            if (!__instance.Owner.Alive)
            {
                data.source.TryGet(out var agent);
                if (agent.IsLocallyOwned)
                {

                    GiveXp(__instance.Owner);
                }
                else
                {
                    var source = agent.TryCast<PlayerAgent>();
                    GiveXp(__instance.Owner, source);
                }
            }
        }

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

        internal static List<string> _aliveEnemieNames = new List<string>();

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
            //Enemy was alive in the postfix but dead now :).
            if(__state && !__instance.Owner.Alive)
            {
                data.source.TryGet(out var source);
                if (source.IsLocallyOwned)
                {
                    GiveXp(__instance.Owner);
                }
                else
                {

                    GiveXp(__instance.Owner, source.TryCast<PlayerAgent>());
                }
            }
        }

        private static Task CheckIfReceiveXp(EnemyAgent enemy, PlayerAgent source)
        {
            if(!_aliveEnemieNames.Contains(enemy.name))
            {
                return Task.CompletedTask;
            }

            lock (_lockObject)
            {
                LogManager.Debug("In LockObject");
                if (!enemy.Alive && _aliveEnemieNames.Contains(enemy.name))
                {
                    _aliveEnemieNames.Remove(enemy.name);
                    
                }
            }
            return Task.CompletedTask;
        }

        private static void GiveXp(EnemyAgent killedEnemy, PlayerAgent sourceAgent = null, bool forceDebuffXp = false)
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

            var position = killedEnemy.Position;
            position.y = position.y + 1f;
            if (sourceAgent is null)
            {
                if (instanceCache.TryGetInstance<XpHandler>(out var xpHandler))
                {
                    xpHandler.AddXp(enemyXpData, position, forceDebuffXp);
                }
            }
            else
            {
                NetworkApiXpManager.SendReceiveXp(sourceAgent, enemyXpData, position);
            }
        }
    }
}
