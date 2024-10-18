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

        public CustomScaling CustomBuff { get; set; } = CustomScaling.Invalid;
        public float Value { get; set; }
    }
}
