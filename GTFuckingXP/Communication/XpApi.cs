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
                xpHandler.CheckForLevelThresholdReached(default, out var header);

                instance.GetInstance<XpBar>().UpdateUiString(instance.GetActiveLevel(), xpHandler.NextLevel, xpHandler.CurrentTotalXp, header);
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

                var levelLayout = instanceCache.GetCurrentLevelLayout();
                var xpHandler = instanceCache.GetInstance<XpHandler>();

                var newLevel = levelLayout.Levels.First(it => it.LevelNumber == levelNumber);

                xpHandler.ChangeCurrentLevel(newLevel, BoosterBuffManager.Instance.GetFittingBoosterBuff(levelLayout.PersistentId, newLevel.LevelNumber));

                cheatedXp = (int)newLevel.TotalXpRequired - (int)xpHandler.CurrentTotalXp;

                xpHandler.CurrentTotalXp = newLevel.TotalXpRequired + 1;
                xpHandler.NextLevel = levelLayout.Levels.FirstOrDefault(it => it.LevelNumber == levelNumber + 1);
                instanceCache.GetInstance<XpBar>().UpdateUiString(instanceCache.GetActiveLevel(), xpHandler.NextLevel, xpHandler.CurrentTotalXp, levelLayout.Header);
            }
            catch (Exception e)
            {
                LogManager.Error(e);
                cheatedXp = 0;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Changes the level class of the player to the <see cref="LevelLayout"/> where <see cref="LevelLayout.Header"/> is the same as <paramref name="header"/>.
        /// </summary>
        /// <param name="header">The header of the new levelLayout.</param>
        /// <returns>If the api call was successful.</returns>
        public static bool ChangeCurrentLevelLayout(string header)
        {
            try
            {
                var instanceCache = InstanceCache.Instance;
                var newLevelLayout = instanceCache.GetInstance<List<LevelLayout>>().First(it => it.Header == header);
                return ChangeCurrentLevelLayout(newLevelLayout);
            }
            catch (Exception e)
            {
                LogManager.Error(e);
                return false;
            }
        }

        /// <summary>
        /// Changes the level class of the player to the <paramref name="newActiveLevelLayout"/>. <br/>
        /// This call may give yourself some xp depending on if the level 1 in the other levellayout only needs 150XP but now needs 400XP which will just 
        /// </summary>
        /// <param name="newActiveLevelLayout">The new <see cref="LevelLayout"/> that should be applied.</param>
        /// <returns>If the api call was successful.</returns>
        public static bool ChangeCurrentLevelLayout(LevelLayout newActiveLevelLayout)
        {
            try
            {
                bool returnBool = true;
                var instanceCache = InstanceCache.Instance;

                instanceCache.SetCurrentLevelLayout(newActiveLevelLayout);
                if (instanceCache.TryGetInstance<XpHandler>(out var xpHandler))
                {
                    var oldTotalXp = xpHandler.CurrentTotalXp;
                    returnBool = SetCurrentLevel(0, out _) && SetCurrentTotalXp(oldTotalXp, out _);
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
        /// Adds <paramref name="lvlUpCallback"/> to the lvl up callback list, invoked whenever the local players achieves another level.
        /// </summary>
        /// <param name="lvlUpCallback">The event that should be called, </param>
        public static void AddOnLevelUpCallback(Action<int> lvlUpCallback)
        {
            var lvlUpCallbackList = InstanceCache.Instance.GetInstance<List<Action<int>>>();
            lvlUpCallbackList.Add(lvlUpCallback);
        }
    }
}
