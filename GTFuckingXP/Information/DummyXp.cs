namespace GTFuckingXP.Information
{
    internal class DummyXp : IXpData
    {
        public DummyXp(uint xpGain, uint debuffXp)
        {
            XpGain = xpGain;
            DebuffXp = debuffXp;
            LevelScalingXpDecrese = 0;
        }

        public uint XpGain { get; set; }
        public uint DebuffXp { get; set; }
        public int LevelScalingXpDecrese { get; set; }
    }
}
