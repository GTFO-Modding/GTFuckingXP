using System.Runtime.InteropServices;

namespace GTFuckingXP.Information.NetworkingInfo
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LevelReachedInfo
    {
        public LevelReachedInfo(int levelNumber, float healthMultiplier, string customScaling)
        {
            LevelNumber = levelNumber;
            HealthMultiplier = healthMultiplier;
            CustomScaling = customScaling;
        }

        //public LevelReachedInfo(Level.Level newLevel)
        //{
        //    LevelNumber = newLevel.LevelNumber;
        //    HealthMultiplier = newLevel.HealthMultiplier;

        //    CustomScaling = JsonSerializer.Serialize(
        //        newLevel.CustomScaling is null ? 
        //        new System.Collections.Generic.List<Level.CustomScalingBuff>() : 
        //        newLevel.CustomScaling);
        //}

        public int LevelNumber;
        public float HealthMultiplier;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 230)]
        public string CustomScaling;
    }
}
