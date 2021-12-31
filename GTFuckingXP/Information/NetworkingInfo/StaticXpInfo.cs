namespace GTFuckingXP.Information.NetworkingInfo
{
    public struct StaticXpInfo : IXpData
    {
        public StaticXpInfo(uint xpGain, uint debuffXp, int levelScaling)
        {
            XpGain = xpGain;
            DebuffXp = debuffXp;
            LevelScalingXpDecrese = levelScaling;
        }

        public uint XpGain { get; set; }
        public uint DebuffXp { get; set; }
        public int LevelScalingXpDecrese { get; set; }
    }
}
