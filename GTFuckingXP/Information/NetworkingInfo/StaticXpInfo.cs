using UnityEngine;

namespace GTFuckingXP.Information.NetworkingInfo
{
    public struct StaticXpInfo : IXpData
    {
        public StaticXpInfo(uint xpGain, uint debuffXp, int levelScaling, Vector3 position)
        {
            XpGain = xpGain;
            DebuffXp = debuffXp;
            LevelScalingXpDecrese = levelScaling;
            Position = position;
        }

        public uint XpGain { get; set; }
        public uint DebuffXp { get; set; }
        public int LevelScalingXpDecrese { get; set; }
        public Vector3 Position { get; set; }
    }
}
