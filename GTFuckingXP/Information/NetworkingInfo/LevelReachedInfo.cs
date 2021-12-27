namespace GTFuckingXP.Information.NetworkingInfo
{
    public struct LevelReachedInfo
    {
        public LevelReachedInfo(Level.Level newLevel)
        {
            LevelNumber = newLevel.LevelNumber;
            HealthMultiplier = newLevel.HealthMultiplier;
        }

        public LevelReachedInfo(int levelNumber, float healthMultiplier)
        {
            LevelNumber = levelNumber;
            HealthMultiplier = healthMultiplier;
        }

        public int LevelNumber { get; set; }
        public float HealthMultiplier { get; set; }
    }
}
