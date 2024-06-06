using System.Collections.Generic;

namespace GTFuckingXP.Information.Enemies.Scale
{
    public class ZoneToEnemyId
    {
        public ZoneToEnemyId(int zone, List<uint> enemyLevelIds)
        {
            Zone = zone;
            EnemyLevelIds = enemyLevelIds;
        }

        public int Zone { get; set; }
        public List<uint> EnemyLevelIds { get; set; }
    }
}
