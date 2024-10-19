using EndskApi.Enums.EnemyKill;
using EndskApi.Information.EnemyKill;
using EndskApi.Manager;
using EndskApi.Patches.EnemyKill;
using Enemies;
using Player;
using System;
using System.Collections.Generic;

namespace EndskApi.Api
{
    public static class EnemyKillApi
    {
        private const string EnemyKillKey = "EnemyKillCallbacks";
        private static bool _setup = false;

        private static Dictionary<IntPtr, bool> _enemyStates = new Dictionary<IntPtr, bool>();

        /// <summary>
        /// Adds a callback to whenever an enemy dies.
        /// THIS FUNCTIONALITY IS HOST ONLY!
        /// </summary>
        /// <param name="callBack"></param>
        public static void AddEnemyKilledCallback(Action<EnemyKillDistribution> callBack)
        {
            Setup();
            if (!CacheApi.TryGetInformation<List<Action<EnemyKillDistribution>>>(EnemyKillKey, out var callBackList, CacheApi.InternalCache, false))
            {
                callBackList = new List<Action<EnemyKillDistribution>>();
                CacheApi.SaveInformation(EnemyKillKey, callBackList, CacheApi.InternalCache);
            }

            callBackList.Add(callBack);
        }

        internal static void InvokeEnemyKilledCallbacks(EnemyKillDistribution enemyKill)
        {
            if (CacheApi.TryGetInformation<List<Action<EnemyKillDistribution>>>(EnemyKillKey, out var callBackList, CacheApi.InternalCache, false))
            {
                foreach (var callBack in callBackList)
                {
                    callBack.Invoke(enemyKill);
                }
            }
        }

        private static void Setup()
        {
            if (!_setup)
            {
                EnemyDamageBasePatchApi.AddReceiveMeleePrefix(1, ReceiveMeleePrefix);
                EnemyDamageBasePatchApi.AddReceiveMeleePostfix(1, ReceiveMeleePostfix);
                EnemyDamageBasePatchApi.AddReceiveBulletPrefix(1, ReceiveBulletPrefix);
                EnemyDamageBasePatchApi.AddReceiveBulletPostfix(1, ReceiveBulletPostfix);
                EnemyDamageBasePatchApi.AddReceiveExplosionPrefix(1, ReceiveExplosionPrefix);
                EnemyDamageBasePatchApi.AddReceiveExplosionPostfix(1, ReceiveExplosionPostfix);
                CacheApi.SaveInstance(new Dictionary<IntPtr, EnemyKillDistribution>(), CacheApi.InternalCache);

                EndskApi.Api.LevelApi.AddEndLevelCallback(() =>
                {
                    _enemyStates = new Dictionary<IntPtr, bool>();
                    CacheApi.SaveInstance(new Dictionary<IntPtr, EnemyKillDistribution>(), CacheApi.InternalCache);
                });

                _setup = true;
            }
        }

        private static void ReceiveMeleePrefix(Dam_EnemyDamageBase instance, ref pFullDamageData data)
        {
            LogManager.Debug($"Receive Melee EnemyKillApi Prefix State = {instance.Owner.Alive}");
            _enemyStates[instance.Pointer] = instance.Owner.Alive;
        }

        private static void ReceiveMeleePostfix(Dam_EnemyDamageBase instance, ref pFullDamageData data)
        {
            LogManager.Debug($"Receive Melee EnemyKillApi Postfix State = {instance.Owner.Alive}");
            if (_enemyStates.TryGetValue(instance.Pointer, out var state) && state)
            {
                data.source.TryGet(out var agent);
                if (agent == null)
                {
                    return;
                }
                var source = agent.TryCast<PlayerAgent>();
                DamageDistributionAddDamageDealt(instance.Owner, source, data.damage.Get(instance.HealthMax));

                if (!instance.Owner.Alive)
                {
                    EnemyDied(instance.Owner, source, LastHitType.Melee);
                }
            }
        }

        private static void ReceiveBulletPrefix(Dam_EnemyDamageBase instance, ref pBulletDamageData data)
        {
            _enemyStates[instance.Pointer] = instance.Owner.Alive;
        }

        private static void ReceiveBulletPostfix(Dam_EnemyDamageBase instance, ref pBulletDamageData data)
        {
            if (_enemyStates.TryGetValue(instance.Pointer, out var state) && state)
            {
                data.source.TryGet(out var agent);
                if (agent == null)
                {
                    return;
                }
                var source = agent.TryCast<PlayerAgent>();
                DamageDistributionAddDamageDealt(instance.Owner, source, data.damage.Get(instance.HealthMax));

                if (!instance.Owner.Alive)
                {
                    EnemyDied(instance.Owner, source, LastHitType.ShootyWeapon);
                }
            }
        }

        private static void ReceiveExplosionPrefix(Dam_EnemyDamageBase instance, PlayerAgent? source, ref pExplosionDamageData data)
        {
            _enemyStates[instance.Pointer] = instance.Owner.Alive;
        }

        private static void ReceiveExplosionPostfix(Dam_EnemyDamageBase instance, PlayerAgent? source, ref pExplosionDamageData data)
        {
            if (_enemyStates.TryGetValue(instance.Pointer, out var state) && state)
            {
                if (source != null)
                {
                    DamageDistributionAddDamageDealt(instance.Owner, source, data.damage.Get(instance.HealthMax));
                }

                if (!instance.Owner.Alive)
                {
                    EnemyDied(instance.Owner, source, LastHitType.Explosion);
                }
            }
        }

        private static void DamageDistributionAddDamageDealt(EnemyAgent hitEnemy, PlayerAgent damageDealer, float damageDealt)
        {
            var damageDistribution = CacheApi.GetInstance<Dictionary<IntPtr, EnemyKillDistribution>>(CacheApi.InternalCache);

            if (!damageDistribution.ContainsKey(hitEnemy.Pointer))
            {
                var distribution = new EnemyKillDistribution(hitEnemy);
                distribution.AddDamageDealtByPlayerAgent(damageDealer, damageDealt);
                damageDistribution[hitEnemy.Pointer] = distribution;
                return;
            }

            damageDistribution[hitEnemy.Pointer].AddDamageDealtByPlayerAgent(damageDealer, damageDealt);
        }

        private static void EnemyDied(EnemyAgent hitEnemy, PlayerAgent lastHit, LastHitType lastHitType)
        {
            var damageDistribution = CacheApi.GetInstance<Dictionary<IntPtr, EnemyKillDistribution>>(CacheApi.InternalCache);
            if (damageDistribution.TryGetValue(hitEnemy.Pointer, out EnemyKillDistribution distribution))
            {
                distribution.LastHitDealtBy = lastHit;
                distribution.lastHitType = lastHitType;

                EnemyKillApi.InvokeEnemyKilledCallbacks(distribution);
            }
        }
    }
}
