namespace XpExpansions.Information.StartingXp
{
    public class StartingXpData
    {
        public StartingXpData(uint levelLayoutData, uint startingXp)
        {
            LevelLayoutData = levelLayoutData;
            StartingXp = startingXp;
        }

        public uint LevelLayoutData { get; set; }
        public uint StartingXp { get; set; }
    }
}
