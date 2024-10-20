using Agents;
using EndskApi.Patches.EnemyKill;
using Player;
using UnityEngine;

namespace EndskApi.Api
{
    public static class EnemyDamageBasePatchApi
    {
        private static bool _setup;

        public unsafe delegate void ReceiveMeleeDamage(Dam_EnemyDamageBase instance, ref pFullDamageData data);
        public delegate void ReceiveBulletDamage(Dam_EnemyDamageBase instance, ref pBulletDamageData data);
        public delegate void ReceiveExplosionDamage(Dam_EnemyDamageBase instance, PlayerAgent? source, ref pExplosionDamageData data);
        public delegate void ProcessReceivedDamage(Dam_EnemyDamageBase instance, ref float damage, Agent damageSource, ref Vector3 position, ref Vector3 direction, ref ES_HitreactType hitreact, ref bool tryForceHitreact, ref int limbID, ref float staggerDamageMulti, ref DamageNoiseLevel damageNoiseLevel);

        internal static List<(double, ReceiveMeleeDamage)> MeleePrefixCallbacks
        {
            get => CacheApi.GetInstance<List<(double, ReceiveMeleeDamage)>>(CacheApi.InternalCache);
            set => CacheApi.SaveInstance<List<(double, ReceiveMeleeDamage)>>(value, CacheApi.InternalCache);
        }

        internal static List<(double, ReceiveMeleeDamage)> MeleePostfixCallbacks
        {
            get => CacheApi.GetInstance<List<(double, ReceiveMeleeDamage)>>();
            set => CacheApi.SaveInstance<List<(double, ReceiveMeleeDamage)>>(value);
        }

        internal static List<(double, ReceiveBulletDamage)> BulletPrefixCallbacks
        {
            get => CacheApi.GetInstance<List<(double, ReceiveBulletDamage)>>(CacheApi.InternalCache);
            set => CacheApi.SaveInstance<List<(double, ReceiveBulletDamage)>>(value, CacheApi.InternalCache);
        }

        internal static List<(double, ReceiveBulletDamage)> BulletPostfixCallbacks
        {
            get => CacheApi.GetInstance<List<(double, ReceiveBulletDamage)>>();
            set => CacheApi.SaveInstance<List<(double, ReceiveBulletDamage)>>(value);
        }

        internal static List<(double, ReceiveExplosionDamage)> ExplosionPrefixCallbacks
        {
            get => CacheApi.GetInstance<List<(double, ReceiveExplosionDamage)>>(CacheApi.InternalCache);
            set => CacheApi.SaveInstance<List<(double, ReceiveExplosionDamage)>>(value, CacheApi.InternalCache);
        }

        internal static List<(double, ReceiveExplosionDamage)> ExplosionPostfixCallbacks
        {
            get => CacheApi.GetInstance<List<(double, ReceiveExplosionDamage)>>();
            set => CacheApi.SaveInstance<List<(double, ReceiveExplosionDamage)>>(value);
        }

        //internal static List<(double, ProcessReceivedDamage)> ProcessDamagePrefixCallbacks
        //{
        //    get => CacheApi.GetInstance<List<(double, ProcessReceivedDamage)>>(CacheApi.InternalCache);
        //    set => CacheApi.SaveInstance<List<(double, ProcessReceivedDamage)>>(value, CacheApi.InternalCache);
        //}

        //internal static List<(double, ProcessReceivedDamage)> ProcessDamagePostfixCallbacks
        //{
        //    get => CacheApi.GetInstance<List<(double, ProcessReceivedDamage)>>();
        //    set => CacheApi.SaveInstance<List<(double, ProcessReceivedDamage)>>(value);
        //}

        internal static void Setup()
        {
            if (!_setup)
            {
                BepInExLoader.Harmony.PatchAll(typeof(EnemyDamageBasePatches));
                BepInExLoader.Harmony.PatchAll(typeof(MineDeployerExplosivePatches));

                MeleePrefixCallbacks = new List<(double, ReceiveMeleeDamage)>();
                MeleePostfixCallbacks = new List<(double, ReceiveMeleeDamage)>();
                BulletPrefixCallbacks = new List<(double, ReceiveBulletDamage)>();
                BulletPostfixCallbacks = new List<(double, ReceiveBulletDamage)>();
                ExplosionPrefixCallbacks = new List<(double, ReceiveExplosionDamage)>();
                ExplosionPostfixCallbacks = new List<(double, ReceiveExplosionDamage)>();
                //ProcessDamagePrefixCallbacks = new List<(double, ProcessReceivedDamage)>();
                //ProcessDamagePostfixCallbacks = new List<(double, ProcessReceivedDamage)>();
                _setup = true;
            }
        }

        public static void AddReceiveMeleePrefix(double priority, ReceiveMeleeDamage method)
        {
            Setup();
            MeleePrefixCallbacks.Add((priority, method));
            MeleePrefixCallbacks = new (MeleePrefixCallbacks.OrderBy(x => x.Item1));
        }

        public static void AddReceiveMeleePostfix(double priority, ReceiveMeleeDamage method)
        {
            Setup();
            MeleePostfixCallbacks.Add((priority, method));
            MeleePostfixCallbacks = new(MeleePostfixCallbacks.OrderBy(x => x.Item1));
        }

        public static void AddReceiveBulletPrefix(double priority, ReceiveBulletDamage method)
        {
            Setup();
            BulletPrefixCallbacks.Add((priority, method));
            BulletPrefixCallbacks = new(BulletPrefixCallbacks.OrderBy(x => x.Item1));
        }

        public static void AddReceiveBulletPostfix(double priority, ReceiveBulletDamage method)
        {
            Setup();
            BulletPostfixCallbacks.Add((priority, method));
            BulletPostfixCallbacks = new(BulletPostfixCallbacks.OrderBy(x => x.Item1));
        }

        public static void AddReceiveExplosionPrefix(double priority, ReceiveExplosionDamage method)
        {
            Setup();
            ExplosionPrefixCallbacks.Add((priority, method));
            ExplosionPrefixCallbacks = new(ExplosionPrefixCallbacks.OrderBy(x => x.Item1));
        }

        public static void AddReceiveExplosionPostfix(double priority, ReceiveExplosionDamage method)
        {
            Setup();
            ExplosionPostfixCallbacks.Add((priority, method));
            ExplosionPostfixCallbacks = new(ExplosionPostfixCallbacks.OrderBy(x => x.Item1));
        }

        //public static void AddProcessReceivedDamagePrefix(double priority, ProcessReceivedDamage method)
        //{
        //    Setup();
        //    ProcessDamagePrefixCallbacks.Add((priority, method));
        //    ProcessDamagePrefixCallbacks = new(ProcessDamagePrefixCallbacks.OrderBy(x => x.Item1));
        //}

        //public static void AddProcessReceivedDamagePostfix(double priority, ProcessReceivedDamage method)
        //{
        //    Setup();
        //    ProcessDamagePostfixCallbacks.Add((priority, method));
        //    ProcessDamagePostfixCallbacks = new(ProcessDamagePostfixCallbacks.OrderBy(x => x.Item1));
        //}

        internal static void InvokeReceiveMeleePrefix(Dam_EnemyDamageBase instance, ref pFullDamageData data)
        {
            foreach (var callBack in MeleePrefixCallbacks)
            {
                callBack.Item2(instance, ref data);
            }
        }

        internal static void InvokeReceiveMeleePostfix(Dam_EnemyDamageBase instance, ref pFullDamageData data)
        {
            foreach (var callBack in MeleePostfixCallbacks)
            {
                callBack.Item2(instance, ref data);
            }
        }

        internal static void InvokeReceiveBulletPrefix(Dam_EnemyDamageBase instance, ref pBulletDamageData data)
        {
            foreach (var callback in BulletPrefixCallbacks)
            {
                callback.Item2(instance, ref data);
            }
        }

        internal static void InvokeReceiveBulletPostfix(Dam_EnemyDamageBase instance, ref pBulletDamageData data)
        {
            foreach (var callback in BulletPostfixCallbacks)
            {
                callback.Item2(instance, ref data);
            }
        }

        internal static void InvokeReceiveExplosionPrefix(Dam_EnemyDamageBase instance, ref pExplosionDamageData data)
        {
            foreach (var callback in ExplosionPrefixCallbacks)
            {
                callback.Item2(instance, MineDeployerExplosivePatches.CachedAgent, ref data);
            }
        }

        internal static void InvokeReceiveExplosionPostfix(Dam_EnemyDamageBase instance, ref pExplosionDamageData data)
        {
            foreach (var callback in ExplosionPostfixCallbacks)
            {
                callback.Item2(instance, MineDeployerExplosivePatches.CachedAgent, ref data);
            }
        }

        //internal static void InvokeProcessReceivedDamagePrefix(Dam_EnemyDamageBase instance, ref float damage, Agent damageSource, ref Vector3 position, ref Vector3 direction, ref ES_HitreactType hitreact, ref bool tryForceHitreact, ref int limbID, ref float staggerDamageMulti, ref DamageNoiseLevel damageNoiseLevel)
        //{
        //    foreach (var callback in ProcessDamagePrefixCallbacks)
        //    {
        //        callback.Item2(instance, ref damage, damageSource, ref position, ref direction, ref hitreact, ref tryForceHitreact, ref limbID, ref staggerDamageMulti, ref damageNoiseLevel);
        //    }
        //}

        //internal static void InvokeProcessReceivedDamagePostfix(Dam_EnemyDamageBase instance, ref float damage, Agent damageSource, ref Vector3 position, ref Vector3 direction, ref ES_HitreactType hitreact, ref bool tryForceHitreact, ref int limbID, ref float staggerDamageMulti, ref DamageNoiseLevel damageNoiseLevel)
        //{
        //    foreach (var callback in ProcessDamagePostfixCallbacks)
        //    {
        //        callback.Item2(instance, ref damage, damageSource, ref position, ref direction, ref hitreact, ref tryForceHitreact, ref limbID, ref staggerDamageMulti, ref damageNoiseLevel);
        //    }
        //}
    }
}
