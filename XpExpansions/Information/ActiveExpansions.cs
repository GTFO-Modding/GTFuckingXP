namespace XpExpansions.Information
{
    public class ActiveExpansions
    {
        public ActiveExpansions(bool explosionAbility, bool doubleJumpAbility)
        {
            ExplosionAbility = explosionAbility;
            DoubleJumpAbility = doubleJumpAbility;
        }

        public bool ExplosionAbility { get; set; }
        public bool DoubleJumpAbility { get; set; }
    }
}
