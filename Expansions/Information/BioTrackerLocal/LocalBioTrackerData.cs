namespace XpExpansions.Information.BioTrackerLocal
{
    internal class LocalBioTrackerData
    {
        public LocalBioTrackerData(int levelLayoutPersistentId, int unlockAtLevel)
        {
            LevelLayoutPersistentId = levelLayoutPersistentId;
            UnlockAtLevel = unlockAtLevel;
        }

        public int LevelLayoutPersistentId { get; set; }

        public int UnlockAtLevel { get; set; }
    }
}
