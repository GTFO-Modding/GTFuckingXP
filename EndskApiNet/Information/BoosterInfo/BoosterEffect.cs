namespace EndskApi.Information.BoosterInfo
{
    public class BoosterEffect
    {
        public BoosterEffect(string name, string shortName, AgentModifier effect, float value)
        {
            Name = name;
            ShortName = shortName;
            Effect = effect;
            Value = value;
        }

        public string Name { get; set; }
        public string ShortName { get; set; }

        public AgentModifier Effect { get; set; }

        public float Value { get; set; }
    }
}
