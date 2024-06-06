using System.Collections.Generic;

namespace GTFuckingXP.Information.Enemies.Scale
{
    public class LevelEnemyScaler
    {
        public LevelEnemyScaler(eRundownTier tier, int expeditionIndex, List<ZoneToEnemyId> zoneToEnemyIds)
        {
            Tier = tier;
            ExpeditionIndex = expeditionIndex;
            ZoneToEnemyIds = zoneToEnemyIds;
        }

        public eRundownTier Tier { get; set; }
        public int ExpeditionIndex { get; set; }
        public List<ZoneToEnemyId> ZoneToEnemyIds { get; set; }
    }
}
