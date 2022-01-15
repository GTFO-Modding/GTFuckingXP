namespace GTFuckingXP.Information.Enemies.Scaling
{
    /// <summary>
    /// A information class that represents how an enemy should be scaled when this instance is active.
    /// </summary>
    public class EnemyLevel
    {
        public EnemyLevel(uint enemyId, int spawningZone, string tagText, float hpMultiplier, 
            float shooterDamageMultiplier, float meleeDamageMultiplier, float pushDamageMultiplier)
        {
            EnemyId = enemyId;
            SpawningZone = spawningZone;
            MaxHealthMultiplier = hpMultiplier;
            ShooterDamageMultiplier = shooterDamageMultiplier;
            MeleeDamageMultiplier = meleeDamageMultiplier;
            PushDamageMutliplier = pushDamageMultiplier;
        }

        /// <summary>
        /// The enemies persistentId.
        /// </summary>
        public uint EnemyId { get; set; }
        public int SpawningZone { get; set; }

        public string TagText { get; set; }
        public float MaxHealthMultiplier { get; set; }
        public float ShooterDamageMultiplier { get; set; }
        public float MeleeDamageMultiplier { get; set; }
        public float PushDamageMutliplier { get; set; }
    }
}
