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

        public readonly SingleBuff SingleBuff = SingleBuff.Invalid;

        public readonly float Value;
    }
}
