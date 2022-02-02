using EndskApi.Api;
using GTFuckingXP.Extensions;
using GTFuckingXP.Information.Level;
using Player;
using System.Collections.Generic;
using System.Linq;

namespace GTFuckingXP.Managers
{
    public class BoosterBuffManager
    {
        public static BoosterBuffManager Instance { get; set; }

        public void ApplyBoosterEffects(PlayerAgent targetAgent, BoosterBuffs buffs)
        {
            #region ClearingOldBoosterEffects
            List<int> playerBoosters;
            if (!CacheApi.TryGetInformation(targetAgent.Owner.Lookup, out playerBoosters, CacheApiWrapper.XpModCacheName))
            {
                playerBoosters = new List<int>();
            }

            foreach(var boosterId in playerBoosters)
            {
                AgentModifierManager.ClearModifierChange(boosterId);
            }
            #endregion

            playerBoosters = new List<int>();
            if (buffs != null)
            {
                foreach (var buff in buffs.ValueToBoosterEffects)
                {
                    if (buff.Value != 0f)
                    {
                        playerBoosters.Add(AgentModifierManager.AddModifierValue(targetAgent, buff.Key, buff.Value));
                    }
                }
            }

            CacheApi.SaveInformation(targetAgent.Owner.Lookup, playerBoosters, CacheApiWrapper.XpModCacheName);
        }

        public BoosterBuffs GetFittingBoosterBuff(int levelLayoutPersistendId, int levelNumber)
        {
            var boosters = CacheApi.GetInstance<List<BoosterBuffs>>(CacheApiWrapper.XpModCacheName);
            var buff = boosters.FirstOrDefault(it => it.ClassLayoutPersistentId == levelLayoutPersistendId && it.ActiveLevels.Contains(levelNumber));
            LogManager.Debug($"GetfittingBoosterBuff call with {levelLayoutPersistendId} as ID and {levelNumber} as levelNumber. {(buff != null ? $"buff found" : "Buff is null")}");

            return buff;
        }
    }
}
