using GTFuckingXP.Extensions;
using GTFuckingXP.Information.Enemies;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Managers;
using GTFuckingXP.Scripts;
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
            var instanceCache = InstanceCache.Instance;
            var scriptManager = ScriptManager.Instance;

            scriptManager.UpdateEverything();

            if (instanceCache.TryGetInformation<LevelLayout>(InstanceCacheExtensions.LevelLayoutKey, out var levelLayout))
            {
                var lvls = instanceCache.GetInstance<List<LevelLayout>>();
                var newLevelLayout = lvls.FirstOrDefault(it => it.Header == levelLayout.Header);

                var oldActiveLevel = instanceCache.GetActiveLevel();

                instanceCache.SetCurrentLevelLayout(newLevelLayout);

                SetCurrentLevel(oldActiveLevel.LevelNumber);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds <paramref name="xpAmount"/> to the current xp amount.
        /// </summary>
        /// <returns>If the current api call was successful.</returns>
        public static bool AddXp(uint xpAmount)
        {
            if (InstanceCache.Instance.TryGetInstance<XpHandler>(out var xpHandler))
            {
                xpHandler.AddXp(new EnemyXp(0, "", xpAmount, xpAmount, 0), default, false, false);
                xpHandler.CheckForLevelThresholdReached(default, false);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets the current total xp to <paramref name="newTotalXpAmount"/>.
        /// </summary>
        /// <returns>If the call was successful.</returns>
        public static bool SetCurrentTotalXp(uint newTotalXpAmount)
        {
            if (InstanceCache.Instance.TryGetInstance<XpHandler>(out var xpHandler))
            {
                xpHandler.CurrentTotalXp = newTotalXpAmount;
                xpHandler.CheckForLevelThresholdReached(default, false);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets the current level to <paramref name="levelNumber"/>.
        /// </summary>
        /// <returns>If the call was successful.</returns>
        public static bool SetCurrentLevel(int levelNumber)
        {
            var instanceCache = InstanceCache.Instance;

            var levelLayout = instanceCache.GetCurrentLevelLayout().Levels;
            return SetCurrentTotalXp(levelLayout.First(it => it.LevelNumber == levelNumber).TotalXpRequired + 1);
        }
    }
}
