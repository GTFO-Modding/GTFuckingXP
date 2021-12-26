using UnityEngine;

namespace GTFuckingXP.Information.NetworkingInfo
{
    /// <summary>
    /// Struct that contains information needed to send xp distribution data between users.
    /// I hate structs, they just behave a really stupid imo
    /// </summary>
    public struct GtfoApiXpInfo : IXpData
    {
        public GtfoApiXpInfo(uint xpGain, uint debuffXp, int levelScaling, Vector3 position, bool forceDebuffXp = false)
        {
            XpGain = xpGain;
            DebuffXp = debuffXp;    
            LevelScalingXpDecrese = levelScaling;
            ForceDebuffXp = forceDebuffXp;

            PositionX = position.x;
            PositionY = position.y;
            PositionZ = position.z;
        }

        public bool ForceDebuffXp { get; set; }
        public uint XpGain { get; set; }
        public uint DebuffXp { get; set; }
        public int LevelScalingXpDecrese { get; set; }

        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }
    }
}
