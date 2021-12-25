namespace GTFuckingXP.Information.Enemies
{
    public class EnemyScaling
    {
        public EnemyScaling(uint enemyId, eRundownTier tier, int expeditionIndex, 
            float hpMultiplier, float damageMultipliers)
        {
            EnemyId = enemyId;
            Tier = tier;
            ExpeditionIndex = expeditionIndex;
            HpMultiplier = hpMultiplier;
            DamageMultiplier = damageMultipliers;
        }

        public uint EnemyId { get; set; }
        public eRundownTier Tier { get; set; }
        public int ExpeditionIndex { get; set; }

        public float HpMultiplier { get; set; }
        public float DamageMultiplier { get; set; }
    }
}
