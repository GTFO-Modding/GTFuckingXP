using GTFuckingXP.Information.Level;
using GTFuckingXP.Managers;
using Player;

namespace GTFuckingXP.Extensions
{
    /// <summary>
    /// Provides easier usage of <see cref="InstanceCache.GetInformation"/> method by using constant keys.
    /// </summary>
    public static class InstanceCacheExtensions
    {
        private const string LevelLayoutKey = "LevelLayout";
        private const string ActiveLevelKey = "ActiveLevel";
        private const string DefaultDataBlockMaxHpKey = "MaxHpDefault";
        //private const string WaterMarkPrefixKey = "WaterMark";

        public static void SetCurrentLevelLayout(this InstanceCache instanceCache, LevelLayout levelLayout)
        {
            LogManager.Debug("Set current level layout.");
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
        /// Sets the default hp 
        /// </summary>
        public static void SetDefaultMaxHp(this InstanceCache instanceCache, float defaultMaxHp)
        {
            instanceCache.SetInformation(DefaultDataBlockMaxHpKey, defaultMaxHp);
        }

        //public static string GetWaterMarkPrefix(this InstanceCache instanceCache)
        //{
        //    return instanceCache.GetInformation<string>(WaterMarkPrefixKey);
        //}

        //public static void SetWaterMarkPrefix(this InstanceCache instanceCache, string watermarkPrefix)
        //{
        //    instanceCache.SetInformation(WaterMarkPrefixKey, watermarkPrefix);
        //}
    }
}
