using GameData;
using GTFuckingXP.Enums;
using GTFuckingXP.Information.ClassSelector;
using GTFuckingXP.Information.Enemies;
using GTFuckingXP.Information.Enemies.Scaling;
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
                    LogManager.Warn($"No balance datablock found for balance id {enemy.BalancingDataId} ({enemy.name})!");
                    maxHp = 20;
                }
                else
                {
                    maxHp = balanceBlock.Health.HealthMax;
                }

                var levelScaling = (int)(maxHp / 35);

                levelScaling = levelScaling > 0 ? levelScaling : 1;
                enemyXpData.Add(new EnemyXp(enemy.persistentID, enemy.name,
                    (uint)(maxHp / 2.5), (uint)(maxHp / 5), levelScaling));
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

        ///// <summary>
        ///// Gets a default level layout containing the current rundown levels.
        ///// </summary>
        //public static List<LevelLayout> GetDefaultLevelLayout()
        //{
        //    var levelLayouts = new List<LevelLayout>();
        //    #region AllRounder
        //    var levels = new List<Level.Level>();

        //    for(int i = 0; i <= 60; i++)
        //    {
        //        var defaultMultiplier = (float)(1 + (0.25f * i));
        //        //Random calculation so later levels actually take longer in the default levellayout
        //        var xpNeed = Convert.ToUInt32(250 * (0.8 + (0.2 * i)) * i);

        //        var singleUseBuffs = new List<SingleUseBuff>();
        //        if((i % 5) == 0 && i != 0)
        //        {
        //            singleUseBuffs.Add(new SingleUseBuff(SingleBuff.Heal, 1f));
        //            singleUseBuffs.Add(new SingleUseBuff(SingleBuff.Desinfect, 1f));
        //            singleUseBuffs.Add(new SingleUseBuff(SingleBuff.AmmunitionMain, 1f));
        //            singleUseBuffs.Add(new SingleUseBuff(SingleBuff.AmmunitionSpecial, 1f));
        //            singleUseBuffs.Add(new SingleUseBuff(SingleBuff.AmmunitionTool, 1f));
        //        }

        //        levels.Add(new Level.Level(i, xpNeed,defaultMultiplier, defaultMultiplier, defaultMultiplier, singleUseBuffs, new List<CustomScalingBuff>()));
        //    }

        //    levelLayouts.Add(new LevelLayout(1, "All Rounder", 0, "Scales equally acceptable with everything.", levels));
        //    #endregion

        //    #region GlassCannon
        //    var glassLevels = new List<Level.Level>();

        //    for (int i = 0; i <= 12; i++)
        //    {
        //        var defaultMultiplier = (float)(1 + (0.5f * i));
        //        //Random calculation so later levels actually take longer in the default levellayout
        //        var xpNeed = Convert.ToUInt32(150 * (0.8 + (0.2 * i)) * i);

        //        var singleUseBuffs = new List<SingleUseBuff>();
        //        singleUseBuffs.Add(new SingleUseBuff(SingleBuff.Heal, 0.1f));
        //        singleUseBuffs.Add(new SingleUseBuff(SingleBuff.Desinfect, 0.1f));

        //        glassLevels.Add(new Level.Level(i, xpNeed, 0.1f * defaultMultiplier, 1.5f * defaultMultiplier, 1.4f * defaultMultiplier, singleUseBuffs, new List<CustomScalingBuff>()));
        //    }

        //    levelLayouts.Add(new LevelLayout(2, "Glass cannon", 0, "Great scaling, but only 12 levels with no HP.", glassLevels));
        //    #endregion

        //    #region Tank
        //    var tankLevels = new List<Level.Level>();

        //    for (int i = 0; i <= 80; i++)
        //    {
        //        var defaultMultiplier = (float)(1 + (0.1f * i));
        //        //Random calculation so later levels actually take longer in the default levellayout
        //        var xpNeed = Convert.ToUInt32(100 * (0.8 + (0.2 * i)) * i);

        //        var singleUseBuffs = new List<SingleUseBuff>();
        //        if ((i % 2) == 0 && i != 0)
        //        {
        //            singleUseBuffs.Add(new SingleUseBuff(SingleBuff.Heal, 0.5f));
        //            singleUseBuffs.Add(new SingleUseBuff(SingleBuff.Desinfect, 0.2f));
        //        }

        //        tankLevels.Add(new Level.Level(i, xpNeed, 5f * defaultMultiplier, 0.5f * defaultMultiplier, 0.5f * defaultMultiplier, singleUseBuffs, new List<CustomScalingBuff>()));
        //    }

        //    levelLayouts.Add(new LevelLayout(3, "Tank", 0, "Slow overall scaling, very good HP but decreased damage output.", tankLevels));
        //    #endregion

        //    #region Kamikaze
        //    var kamikazeLevels = new List<Level.Level>();

        //    for (int i = 0; i <= 20; i++)
        //    {
        //        var defaultMultiplier = (float)(1 + (0.5f * i));
        //        //Random calculation so later levels actually take longer in the default levellayout
        //        var xpNeed = Convert.ToUInt32(400 * (0.8 + (0.2 * i)) * i);

        //        var singleUseBuffs = new List<SingleUseBuff>();
        //        singleUseBuffs.Add(new SingleUseBuff(SingleBuff.AmmunitionMain, 1f));
        //        singleUseBuffs.Add(new SingleUseBuff(SingleBuff.AmmunitionSpecial, 1f));
        //        singleUseBuffs.Add(new SingleUseBuff(SingleBuff.AmmunitionTool, 1f));

        //        kamikazeLevels.Add(new Level.Level(i, xpNeed, 0.05f * defaultMultiplier, 30f * defaultMultiplier, 0.1f * defaultMultiplier, singleUseBuffs, new List<CustomScalingBuff>()));
        //    }

        //    levelLayouts.Add(new LevelLayout(4, "Kamikaze", 0, "No HP, no weapondamage, melee for life\nBut has a curse of getting regulary useless ammunition.", kamikazeLevels));
        //    #endregion

        //    #region MeleeMain
        //    var meleeMainLevels = new List<Level.Level>();

        //    for (int i = 0; i <= 20; i++)
        //    {
        //        var defaultMultiplier = (float)(1 + (0.25f * i));
        //        //Random calculation so later levels actually take longer in the default levellayout
        //        var xpNeed = Convert.ToUInt32(200 * (0.8 + (0.2 * i)) * i);

        //        var singleUseBuffs = new List<SingleUseBuff>();
        //        singleUseBuffs.Add(new SingleUseBuff(SingleBuff.Heal, 0.2f));

        //        meleeMainLevels.Add(new Level.Level(i, xpNeed, 1f * defaultMultiplier, 1f * defaultMultiplier + 1f, (defaultMultiplier * 0.5f) - 0.5f, singleUseBuffs, new List<CustomScalingBuff>()));
        //    }

        //    levelLayouts.Add(new LevelLayout(5, "Melee Main", 0, "Acceptable scaling, faster leveling\nCapable of tanking some hits and deals great melee damage. May lack a bit of Weapondamage", meleeMainLevels));
        //    #endregion

        //    #region Boxer

        //    var boxer = new List<Level.Level>();

        //    for (int i = 0; i <= 20; i++)
        //    {
        //        var defaultMultiplier = (float)(1 + (0.5f * i));
        //        //Random calculation so later levels actually take longer in the default levellayout
        //        var xpNeed = Convert.ToUInt32(200 * (0.8 + (0.2 * i)) * i);

        //        var singleUseBuffs = new List<SingleUseBuff>();

        //        boxer.Add(new Level.Level(i, xpNeed, defaultMultiplier, defaultMultiplier, 0f, singleUseBuffs, new List<CustomScalingBuff>()));
        //    }

        //    levelLayouts.Add(new LevelLayout(6, "Boxer", 1, "Great Scaling.\nNo weapon damage!\nVery tanky against melee damage but can't withstand any shooter.", boxer));
        //    #endregion

        //    #region SpeedRunner

        //    var speedRunner = new List<Level.Level>();

        //    for (int i = 0; i <= 20; i++)
        //    {
        //        var defaultMultiplier = (float)(1 + (0.5f * i));
        //        //Random calculation so later levels actually take longer in the default levellayout
        //        var xpNeed = Convert.ToUInt32(200 * (0.8 + (0.2 * i)) * i);

        //        var singleUseBuffs = new List<SingleUseBuff>();
        //        singleUseBuffs.Add(new SingleUseBuff(SingleBuff.AmmunitionMain, 0.2f));
        //        singleUseBuffs.Add(new SingleUseBuff(SingleBuff.AmmunitionSpecial, 0.2f));
        //        singleUseBuffs.Add(new SingleUseBuff(SingleBuff.AmmunitionTool, 0.2f));

        //        var customScaling = new List<CustomScalingBuff>();

        //        if (i != 0)
        //        {
        //            customScaling.Add(new CustomScalingBuff(CustomScaling.MeleeHitBoxSizeMultiplier, i * 5));
        //            customScaling.Add(new CustomScalingBuff(CustomScaling.MeleeRangeMultiplier, i));
        //            customScaling.Add(new CustomScalingBuff(CustomScaling.MovementSpeedMultiplier, 1 + (i * 0.3f)));
        //            customScaling.Add(new CustomScalingBuff(CustomScaling.AntiFogSphere, i*2));
        //        }
        //        speedRunner.Add(new Level.Level(i, xpNeed, defaultMultiplier, defaultMultiplier, 0f, singleUseBuffs, customScaling));
        //    }

        //    levelLayouts.Add(new LevelLayout(7, "SpeedRunner", 1, "Gets increasingly faster while playing, so you can circle kite even easier.", speedRunner));

        //    #endregion

        //    return levelLayouts;
        //}

        //public static List<BoosterBuffs> GetDefaultBoosterBuffs()
        //{
        //    var boosters = new List<BoosterBuffs>();

        //    boosters.Add(new BoosterBuffs(6, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 },
        //        new Dictionary<AgentModifier, float>() { { AgentModifier.MeleeResistance, 1000f }, {AgentModifier.ProjectileResistance, -500f} }));

        //    return boosters;
        //}

        //public static List<Group> GetDefaultGroups()
        //{
        //    var groups = new List<Group>();

        //    groups.Add(new Group(0, "Example Classes", new List<int>() { 1,2,3,4}));
        //    groups.Add(new Group(1, "For gods sake, don't use it", new List<int> { 1}));

        //    return groups;
        //}

        //public static List<EnemyScaling> GetDefaultEnemyScaling()
        //{
        //    var enemyScaling = new List<EnemyScaling>();

        //    var rundown = RundownDataBlock.GetAllBlocks();
        //    var levels = LevelLayoutDataBlock.GetAllBlocks();
        //    var enemies = EnemyDataBlock.GetAllBlocks();

        //    var tierA = rundown.FirstOrDefault().TierA;
        //    foreach(var expedition in tierA)
        //    {
        //        var level = levels.FirstOrDefault(it => it.persistentID == expedition.LevelLayoutData);
        //        if (level != null)
        //        {
        //            var lastZoneNumber = (int)level.Zones[level.Zones.Count - 1].LocalIndex + level.ZoneAliasStart;
        //            var defaultScaling = new EnemyDefaultZoneLevel(lastZoneNumber, "<size=50>Default</size><#f80>Lvl.1",
        //                1.1f, 1.1f, 1.1f, 1.1f);



        //            var scalingA = new EnemyScaling(eRundownTier.TierA, 0,
        //           new List<EnemyDefaultZoneLevel>() { defaultScaling }, 
        //           new List<EnemyLevel>() { new EnemyLevel(enemies[1].persistentID, (int)level.Zones[0].LocalIndex, 
        //           "<size=50>Strong</size><#f80>Lvl.2", 1.2f, 1.2f, 1.2f, 1.2f)});
        //            enemyScaling.Add(scalingA);
        //        }
        //    }

        //    return enemyScaling;
        //}
    }
}
