using GTFuckingXP.Enums;

namespace GTFuckingXP.Information.Level
{
    /// <summary>
    /// Used to contain information about certain buffs to apply at a level.
    /// </summary>
    public class LevelBuffs
    {
        public LevelBuffs()
        {

        }

        public LevelBuffs(float multiplier, PlayerBuff buffEffect)
        {
            Multiplier = multiplier;
            BuffEffect = buffEffect;
        }

        /// <summary>
        /// Gets or sets the multiplier <see cref="BuffEffect"/> should be applied with.
        /// </summary>
        public float Multiplier { get; set; }

        /// <summary>
        /// Gets or sets the effect this buff should do.
        /// </summary>
        public PlayerBuff BuffEffect { get; set; }
    }
}
