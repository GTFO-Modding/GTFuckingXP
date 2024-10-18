using GTFuckingXP.Enums;

namespace GTFuckingXP.Information.Level
{
    public class SingleUseBuff
    {
        public SingleUseBuff(SingleBuff singleBuff, float value)
        {
            SingleBuff = singleBuff;
            Value = value;
        }

        public SingleBuff SingleBuff { get; set; } = SingleBuff.Invalid;

        public float Value { get; set; }
    }
}
