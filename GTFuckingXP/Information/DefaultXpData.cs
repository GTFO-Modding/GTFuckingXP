using GameData;
using GTFuckingXP.Information.Enemies;
using GTFuckingXP.Information.Expeditions;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Managers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTFuckingXP.Information
{
    /// <summary>
    /// Capabple of creating default xp data.
    /// </summary>
    public static class DefaultXpData
    {
        /// <summary>
        /// Gets an enemy xp object for each enemy in the game with a constant 20 killXp value.
        /// </summary>
        public static List<EnemyXp> GetDefaultEnemyXp()
        {
            var enemyXpData = new List<EnemyXp>();

            foreach(var enemy in GameData.EnemyDataBlock.GetAllBlocks())
            {
                enemyXpData.Add(new EnemyXp(enemy.persistentID, enemy.name, 20, 10, 2));
            }

            return enemyXpData;
        }

        /// <summary>
        /// Gets for each expedition a mapping object that goes to level layout id 1
        /// </summary>
        /// <returns></returns>
        public static List<ExpeditionsLevelMapping> GetDefaultExpeditionsLevelMapping()
        {
            var expeditionMapping = new List<ExpeditionsLevelMapping>();

            var allBlocks = RundownDataBlock.GetAllBlocks();
            var rundownDataBlock = allBlocks.FirstOrDefault(it => it.persistentID == 1);
            LogManager.Debug($"RundownDataBlock has {(rundownDataBlock is null ? "Null" : "")}");

            if(rundownDataBlock is null)
            {
                rundownDataBlock = allBlocks.OrderByDescending(it => it.persistentID).FirstOrDefault();
                if(rundownDataBlock is null)
                {
                    expeditionMapping.Add(new ExpeditionsLevelMapping(eRundownTier.TierA, 0, 1));
                    return expeditionMapping;
                }
            }

            for (int i = 0; i < rundownDataBlock.TierA.Count; i++)
            {
                expeditionMapping.Add(new ExpeditionsLevelMapping(eRundownTier.TierA, i, 1));
            }

            for (int i = 0; i < rundownDataBlock.TierB.Count; i++)
            {
                expeditionMapping.Add(new ExpeditionsLevelMapping(eRundownTier.TierB, i, 1));
            }

            for (int i = 0; i < rundownDataBlock.TierC.Count; i++)
            {
                expeditionMapping.Add(new ExpeditionsLevelMapping(eRundownTier.TierC, i, 1));
            }

            for (int i = 0; i < rundownDataBlock.TierD.Count; i++)
            {
                expeditionMapping.Add(new ExpeditionsLevelMapping(eRundownTier.TierD, i, 1));
            }

            for (int i = 0; i < rundownDataBlock.TierE.Count; i++)
            {
                expeditionMapping.Add(new ExpeditionsLevelMapping(eRundownTier.TierE, i, 1));
            }

            return expeditionMapping;
        }

        /// <summary>
        /// Gets a default level layout containing the current rundown levels.
        /// </summary>
        public static List<LevelLayout> GetDefaultLevelLayout()
        {
            var levelLayouts = new List<LevelLayout>();
            var levels = new List<Level.Level>();

            for(int i = 0; i < 30; i++)
            {
                var defaultMultiplier = (float)Math.Round(1 + (0.2f * i),2);

                //Random calculation so later levels actually take longer in the default levellayout
                var xpNeed = Convert.ToUInt32(100 * (0.9 + (0.1 * i)) * i);
                levels.Add(new Level.Level(i, xpNeed,defaultMultiplier, defaultMultiplier, defaultMultiplier));
            }

            levelLayouts.Add(new LevelLayout(1, levels));
            return levelLayouts;
        }
    }
}
