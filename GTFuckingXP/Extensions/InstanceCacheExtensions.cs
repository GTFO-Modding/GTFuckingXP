using GTFuckingXP.Information.Level;
using GTFuckingXP.Managers;
using System.Collections.Generic;

namespace GTFuckingXP.Extensions
{
    /// <summary>
    /// Provides easier usage of <see cref="InstanceCache.GetInformation"/> method by using constant keys.
    /// </summary>
    public static class InstanceCacheExtensions
    {
        internal const string LevelLayoutKey = "LevelLayout";
        private const string ActiveLevelKey = "ActiveLevel";
        private const string DefaultDataBlockMaxHpKey = "MaxHpDefault";
        private const string PlayerSlotToLevelIndexMappingKey = "PlayerLevelIndexMapping";
        //private const string WaterMarkPrefixKey = "WaterMark";

        public static void SetCurrentLevelLayout(this InstanceCache instanceCache, LevelLayout levelLayout)
        {
            LogManager.Debug($"Set current level layout to {levelLayout.Header}.");
            instanceCache.SetInformation(LevelLayoutKey, levelLayout);
        }

        public static LevelLayout GetCurrentLevelLayout(this InstanceCache instanceCache)
        {
            return instanceCache.GetInformation<LevelLayout>(LevelLayoutKey);
        }

        /// <summary>
        /// Sets the new current active level to <paramref name="newLevel"/>
        /// </summary>
        public static void SetActiveLevel(this InstanceCache instanceCache, Level newLevel)
        {
            LogManager.Debug($"Setting new level to {newLevel.LevelNumber}.");
            NetworkApiXpManager.SendNewLevelActive(newLevel);
            instanceCache.SetInformation(ActiveLevelKey, newLevel);
        }

        /// <summary>
        /// Gets the current level with all stats.
        /// </summary>
        public static Level GetActiveLevel(this InstanceCache instanceCache)
        {
            return instanceCache.GetInformation<Level>(ActiveLevelKey);
        }

        public static float GetDefaultMaxHp(this InstanceCache instanceCache)
        {
            return instanceCache.GetInformation<float>(DefaultDataBlockMaxHpKey);
        }

        /// <summary>
        /// Sets the default HP.
        /// </summary>
        public static void SetDefaultMaxHp(this InstanceCache instanceCache, float defaultMaxHp)
        {
            instanceCache.SetInformation(DefaultDataBlockMaxHpKey, defaultMaxHp);
        }

        /// <summary>
        /// Sets the player to index map dictionary in the <paramref name="instanceCache"/>.
        /// </summary>
        public static void SetPlayerToLevelMapping(this InstanceCache instanceCache, Dictionary<int, int> playerToLevelMap)
        {
            instanceCache.SetInformation(PlayerSlotToLevelIndexMappingKey, playerToLevelMap);
        }

        public static Dictionary<int, int> GetPlayerToLevelMapping(this InstanceCache instanceCache)
        {
            return instanceCache.GetInformation<Dictionary<int, int>>(PlayerSlotToLevelIndexMappingKey);
        }

    }
}
