namespace GTFuckingXP.Information.Enemies.Scaling
{
    public class EnemyDefaultZoneLevel
    {
        public EnemyDefaultZoneLevel(int spawningZone, string tagText, float hpMultiplier,
            float shooterDamageMultiplier, float meleeDamageMultiplier, float pushDamageMultiplier)
        {
            SpawningZone = spawningZone;
            MaxHealthMultiplier = hpMultiplier;
            ShooterDamageMultiplier = shooterDamageMultiplier;
            MeleeDamageMultiplier = meleeDamageMultiplier;
            PushDamageMutliplier = pushDamageMultiplier;
        }

        public int SpawningZone { get; set; }
        public string TagText { get; set; }
        public float MaxHealthMultiplier { get; set; }
        public float ShooterDamageMultiplier { get; set; }
        public float MeleeDamageMultiplier { get; set; }
        public float PushDamageMutliplier { get; set; }
    }
}
