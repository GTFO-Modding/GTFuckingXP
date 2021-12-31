using GTFuckingXP.Extensions;
using GTFuckingXP.Information.Enemies;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Managers;
using GTFuckingXP.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTFuckingXP.Communication
{
    public static class XpApi
    {
        /// <summary>
        /// Reloads the entire xp data.
        /// </summary>
        /// <returns>If the new layout was applied ingame.</returns>
        public static bool ReloadData()
        {
            try
            {
                var instanceCache = InstanceCache.Instance;
                var scriptManager = ScriptManager.Instance;

                scriptManager.UpdateEverything();

                //There is no real need to change the current Levellayout, this information is only set while in an expedition.
                if (instanceCache.TryGetInformation<LevelLayout>(InstanceCacheExtensions.LevelLayoutKey, out var levelLayout))
                {
                    var lvls = instanceCache.GetInstance<List<LevelLayout>>();
                    var newLevelLayout = lvls.FirstOrDefault(it => it.Header == levelLayout.Header);

                    var oldActiveLevel = instanceCache.GetActiveLevel();

                    instanceCache.SetCurrentLevelLayout(newLevelLayout);

                    SetCurrentLevel(oldActiveLevel.LevelNumber, out _);
                }
             
                return true;
            }
            catch (Exception e)
            {
                LogManager.Error(e);
                return false;
            }
        }

        /// <summary>
        /// Adds <paramref name="xpAmount"/> to the current xp amount.
        /// </summary>
        /// <returns>If the current api call was successful.</returns>
        public static bool AddXp(uint xpAmount)
        {
            try
            {
                var xpHandler = InstanceCache.Instance.GetInstance<XpHandler>();
                xpHandler.AddXp(new EnemyXp(0, "", xpAmount, xpAmount, 0), default, false, false);

                return true;
            }
            catch (Exception e)
            {
                LogManager.Error(e);
                return false;
            }
        }

        /// <summary>
        /// Sets the current total xp to <paramref name="newTotalXpAmount"/>.<br/>
        /// WARNING: This call does not support backwards leveling! Which will cause problems, like a buggy xp bar.<br/>
        /// For lowering levels you may use <see cref="SetCurrentLevel(int, out int)"/>!
        /// </summary>
        /// <returns>If the call was successful.</returns>
        public static bool SetCurrentTotalXp(uint newTotalXpAmount, out int cheatedXp)
        {
            try
            {
                var instance = InstanceCache.Instance;
                var xpHandler = InstanceCache.Instance.GetInstance<XpHandler>();

                cheatedXp = (int)newTotalXpAmount - (int)xpHandler.CurrentTotalXp;

                xpHandler.CurrentTotalXp = newTotalXpAmount;
                xpHandler.CheckForLevelThresholdReached(default, false);

                instance.GetInstance<XpBar>().UpdateUiString(instance.GetActiveLevel(), xpHandler.NextLevel, xpHandler.CurrentTotalXp);
                return true;
            }
            catch (Exception e)
            {
                LogManager.Error(e);
                cheatedXp = 0;
                return false;
            }
        }

        /// <summary>
        /// Sets the current level to <paramref name="levelNumber"/>.
        /// </summary>
        /// <returns>If the call was successful.</returns>
        public static bool SetCurrentLevel(int levelNumber, out int cheatedXp)
        {
            try
            {
                var instanceCache = InstanceCache.Instance;

                var levelLayout = instanceCache.GetCurrentLevelLayout().Levels;
                var xpHandler = instanceCache.GetInstance<XpHandler>();

                var levelWithLevelNumber = levelLayout.First(it => it.LevelNumber == levelNumber);
                xpHandler.ChangeCurrentLevel(levelWithLevelNumber);

                cheatedXp = (int)levelWithLevelNumber.TotalXpRequired - (int)xpHandler.CurrentTotalXp;

                xpHandler.CurrentTotalXp = levelWithLevelNumber.TotalXpRequired + 1;
                xpHandler.NextLevel = levelLayout.FirstOrDefault(it => it.LevelNumber == levelNumber + 1);
                instanceCache.GetInstance<XpBar>().UpdateUiString(instanceCache.GetActiveLevel(), xpHandler.NextLevel, xpHandler.CurrentTotalXp);
            }
            catch(Exception e)
            {
                LogManager.Error(e);
                cheatedXp = 0;
                return false;
            }

            return true;
        }
    }
}
