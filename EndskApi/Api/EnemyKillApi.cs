using EndskApi.Information.EnemyKill;
using EndskApi.Patches.EnemyKill;
using System;
using System.Collections.Generic;

namespace EndskApi.Api
{
    public static class EnemyKillApi
    {
        private const string EnemyKillKey = "EnemyKillCallbacks";

        static EnemyKillApi()
        {
            BepInExLoader.Harmony.PatchAll(typeof(EnemyDamageBasePatches));
        }

        /// <summary>
        /// Adds a callback to whenever an enemy dies.
        /// THIS FUNCTIONALITY IS HOST ONLY!
        /// </summary>
        /// <param name="callBack"></param>
        public static void AddEnemyKilledCallback(Action<EnemyKillDistribution> callBack)
        {
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
    }
}
