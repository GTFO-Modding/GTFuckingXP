namespace GTFuckingXP.Information.NetworkingInfo
{
    //TODO Show in level which level each person is
    public struct LevelReachedInfo
    {
        public LevelReachedInfo(int levelNumber)
        {
            LevelNumber = levelNumber;
        }

        public int LevelNumber { get; set; }
    }
}
