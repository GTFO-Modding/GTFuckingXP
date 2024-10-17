using GTFuckingXP.Enums;

namespace GTFuckingXP.Information.Level
{
    public class CustomScalingBuff
    {
        public CustomScalingBuff(CustomScaling customBuff, float value)
        {
            CustomBuff = customBuff;
            Value = value;
        }

        public readonly CustomScaling CustomBuff = CustomScaling.Invalid;
        public readonly float Value;
    }
}
