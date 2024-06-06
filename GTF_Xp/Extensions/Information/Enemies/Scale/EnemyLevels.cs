namespace GTFuckingXP.Information.Enemies.Scale
{
    public class EnemyLevels
    {
        public EnemyLevels(uint persistentId, int enemyId, int levelNumber, string tagText, float hpMultiplier,
            float shooterDamageMultiplier, float meleeDamageMultiplier, float pushDamageMultiplier)
        {
            PersistendId = persistentId;
            LevelNumber = levelNumber;
            TagText = tagText;
            MaxHealthMultiplier = hpMultiplier;
            ShooterDamageMultiplier = shooterDamageMultiplier;
            MeleeDamageMultiplier = meleeDamageMultiplier;
            PushDamageMutliplier = pushDamageMultiplier;
        }

        public uint PersistendId { get; set; }
        public int EnemyId { get; set; }
        public int LevelNumber { get; set; }
        public string TagText { get; set; }
        public float MaxHealthMultiplier { get; set; }
        public float ShooterDamageMultiplier { get; set; }
        public float MeleeDamageMultiplier { get; set; }
        public float PushDamageMutliplier { get; set; }
    }
}
