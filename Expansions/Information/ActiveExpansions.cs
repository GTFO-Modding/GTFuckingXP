namespace XpExpansions.Information
{
    public class ActiveExpansions
    {
        public ActiveExpansions(bool startingXp, bool doubleJumpAbility)
        {
            DoubleJumpAbility = doubleJumpAbility;
            StartingXp = startingXp;
        }

        public bool DoubleJumpAbility { get; set; }
        public bool StartingXp { get; set; }
        public bool LivingBioAbility { get; set; }
    }
}
