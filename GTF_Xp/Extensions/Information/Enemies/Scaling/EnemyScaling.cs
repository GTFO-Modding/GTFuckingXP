using System.Collections.Generic;

namespace GTFuckingXP.Information.Enemies.Scaling
{
    public class EnemyScaling
    {
        public EnemyScaling(eRundownTier tier, int expeditionIndex, 
            List<EnemyDefaultZoneLevel> zoneLevels, List<EnemyLevel> enemyLevels)
        {
            Tier = tier;
            ExpeditionIndex = expeditionIndex;
        }

        public eRundownTier Tier { get; set; }
        public int ExpeditionIndex { get; set; }
        public List<EnemyDefaultZoneLevel> DefaultScale { get; set; }
        public List<EnemyLevel> EnemyLevels { get; set; }
    }
}
