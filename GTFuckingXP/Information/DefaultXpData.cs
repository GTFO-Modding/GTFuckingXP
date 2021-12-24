using GameData;
using GTFuckingXP.Enums;
using GTFuckingXP.Information.Enemies;
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

            var balancingDataBlocks = EnemyBalancingDataBlock.GetAllBlocks();
            foreach (var enemy in EnemyDataBlock.GetAllBlocks())
            {
                var balanceBlock = balancingDataBlocks.FirstOrDefault(it => it.persistentID == enemy.BalancingDataId);
                float maxHp;
                if (balanceBlock is null)
                {
                    LogManager.Warn($"No balance datablock found for balance id {enemy.BalancingDataId}!");
                    maxHp = 20;
                }
                else
                {
                    maxHp = balanceBlock.Health.HealthMax;
                }

                var levelScaling = (int)(maxHp / 35);

                levelScaling = levelScaling > 0 ? levelScaling : 1;
                enemyXpData.Add(new EnemyXp(enemy.persistentID, enemy.name,
                    (uint)(maxHp / 2), (uint)(maxHp / 4), levelScaling));
            }

            return enemyXpData;
        }

        ///// <summary>
        ///// Gets for each expedition a mapping object that goes to level layout id 1
        ///// </summary>
        ///// <returns></returns>
        //public static List<ExpeditionsLevelMapping> GetDefaultExpeditionsLevelMapping()
        //{
        //    var expeditionMapping = new List<ExpeditionsLevelMapping>();

        //    var allBlocks = RundownDataBlock.GetAllBlocks();
        //    var rundownDataBlock = allBlocks.FirstOrDefault(it => it.persistentID == 1);
        //    LogManager.Debug($"RundownDataBlock has {(rundownDataBlock is null ? "Null" : "")}");

        //    if(rundownDataBlock is null)
        //    {
        //        rundownDataBlock = allBlocks.OrderByDescending(it => it.persistentID).FirstOrDefault();
        //        if(rundownDataBlock is null)
        //        {
        //            expeditionMapping.Add(new ExpeditionsLevelMapping(eRundownTier.TierA, 0, 1));
        //            return expeditionMapping;
        //        }
        //    }

        //    for (int i = 0; i < rundownDataBlock.TierA.Count; i++)
        //    {
        //        expeditionMapping.Add(new ExpeditionsLevelMapping(eRundownTier.TierA, i, 1));
        //    }

        //    for (int i = 0; i < rundownDataBlock.TierB.Count; i++)
        //    {
        //        expeditionMapping.Add(new ExpeditionsLevelMapping(eRundownTier.TierB, i, 1));
        //    }

        //    for (int i = 0; i < rundownDataBlock.TierC.Count; i++)
        //    {
        //        expeditionMapping.Add(new ExpeditionsLevelMapping(eRundownTier.TierC, i, 1));
        //    }

        //    for (int i = 0; i < rundownDataBlock.TierD.Count; i++)
        //    {
        //        expeditionMapping.Add(new ExpeditionsLevelMapping(eRundownTier.TierD, i, 1));
        //    }

        //    for (int i = 0; i < rundownDataBlock.TierE.Count; i++)
        //    {
        //        expeditionMapping.Add(new ExpeditionsLevelMapping(eRundownTier.TierE, i, 1));
        //    }

        //    return expeditionMapping;
        //}

        /// <summary>
        /// Gets a default level layout containing the current rundown levels.
        /// </summary>
        public static List<LevelLayout> GetDefaultLevelLayout()
        {
            var levelLayouts = new List<LevelLayout>();
            #region AllRounder
            var levels = new List<Level.Level>();

            for(int i = 0; i < 60; i++)
            {
                var defaultMultiplier = (float)(1 + (0.25f * i));
                //Random calculation so later levels actually take longer in the default levellayout
                var xpNeed = Convert.ToUInt32(250 * (0.8 + (0.2 * i)) * i);

                var singleUseBuffs = new List<SingleUseBuff>();
                if((i % 5) == 0 && i != 0)
                {
                    singleUseBuffs.Add(new SingleUseBuff(SingleBuff.Heal, 1f));
                    singleUseBuffs.Add(new SingleUseBuff(SingleBuff.Desinfect, 1f));
                    singleUseBuffs.Add(new SingleUseBuff(SingleBuff.AmmunitionMain, 1f));
                    singleUseBuffs.Add(new SingleUseBuff(SingleBuff.AmmunitionSpecial, 1f));
                    singleUseBuffs.Add(new SingleUseBuff(SingleBuff.AmmunitionTool, 1f));
                }

                levels.Add(new Level.Level(i, xpNeed,defaultMultiplier, defaultMultiplier, defaultMultiplier, singleUseBuffs));
            }

            levelLayouts.Add(new LevelLayout("All Rounder", "Scales equally acceptable with everything.", levels));
            #endregion

            #region GlassCannon
            var glassLevels = new List<Level.Level>();

            for (int i = 0; i < 12; i++)
            {
                var defaultMultiplier = (float)(1 + (0.5f * i));
                //Random calculation so later levels actually take longer in the default levellayout
                var xpNeed = Convert.ToUInt32(150 * (0.8 + (0.2 * i)) * i);

                var singleUseBuffs = new List<SingleUseBuff>();
                singleUseBuffs.Add(new SingleUseBuff(SingleBuff.Heal, 0.1f));
                singleUseBuffs.Add(new SingleUseBuff(SingleBuff.Desinfect, 0.1f));

                glassLevels.Add(new Level.Level(i, xpNeed, 0.1f * defaultMultiplier, 1.5f * defaultMultiplier, 1.4f * defaultMultiplier, singleUseBuffs));
            }

            levelLayouts.Add(new LevelLayout("Glass cannon", "Great scaling, but only 12 levels with no HP.", glassLevels));
            #endregion

            #region Tank
            var tankLevels = new List<Level.Level>();

            for (int i = 0; i < 80; i++)
            {
                var defaultMultiplier = (float)(1 + (0.1f * i));
                //Random calculation so later levels actually take longer in the default levellayout
                var xpNeed = Convert.ToUInt32(100 * (0.8 + (0.2 * i)) * i);

                var singleUseBuffs = new List<SingleUseBuff>();
                if ((i % 2) == 0 && i != 0)
                {
                    singleUseBuffs.Add(new SingleUseBuff(SingleBuff.Heal, 0.5f));
                    singleUseBuffs.Add(new SingleUseBuff(SingleBuff.Desinfect, 0.2f));
                }

                tankLevels.Add(new Level.Level(i, xpNeed, 5f * defaultMultiplier, 0.5f * defaultMultiplier, 0.5f * defaultMultiplier, singleUseBuffs));
            }

            levelLayouts.Add(new LevelLayout("Tank", "Slow overall scaling, very good HP but decreased damage output.", tankLevels));
            #endregion

            #region Kamikaze
            var kamikazeLevels = new List<Level.Level>();

            for (int i = 0; i < 20; i++)
            {
                var defaultMultiplier = (float)(1 + (0.5f * i));
                //Random calculation so later levels actually take longer in the default levellayout
                var xpNeed = Convert.ToUInt32(400 * (0.8 + (0.2 * i)) * i);

                var singleUseBuffs = new List<SingleUseBuff>();
                singleUseBuffs.Add(new SingleUseBuff(SingleBuff.AmmunitionMain, 1f));
                singleUseBuffs.Add(new SingleUseBuff(SingleBuff.AmmunitionSpecial, 1f));
                singleUseBuffs.Add(new SingleUseBuff(SingleBuff.AmmunitionTool, 1f));

                kamikazeLevels.Add(new Level.Level(i, xpNeed, 0.05f * defaultMultiplier, 30f * defaultMultiplier, 0.1f * defaultMultiplier, singleUseBuffs));
            }

            levelLayouts.Add(new LevelLayout("Kamikaze", "No HP, no weapondamage, melee for life\nBut has a curse of getting regulary useless ammunition.", kamikazeLevels));
            #endregion

            return levelLayouts;
        }
    }
}
