using System.Collections.Generic;

namespace GTFuckingXP.Information.Level
{
    /// <summary>
    /// Contains information to be read as an individual level
    /// </summary>
    public class Level
    {
        public Level()
        { }

        public Level(int levelNumber, uint totalXp, float healthMultiplier, float meleeMultiplier, float weaponMultiplier, List<SingleUseBuff> singleUseBuffs)
        {
            LevelNumber = levelNumber;
            TotalXpRequired = totalXp;

            HealthMultiplier = healthMultiplier;
            MeleeDamageMultiplier = meleeMultiplier;
            WeaponDamageMultiplier = weaponMultiplier;
            SingleUseBuffs = singleUseBuffs;
        }

        /// <summary>
        /// Gets or sets the number this level represents.
        /// </summary>
        public int LevelNumber { get; set; }

        /// <summary>
        /// Gets or sets the amount of xp you need to achieve this level.
        /// </summary>
        public uint TotalXpRequired { get; set; }

        /// <summary>
        /// Gets or sets the amount the basic hp get scaled with this value.
        /// </summary>
        public float HealthMultiplier { get; set; }

        /// <summary>
        /// Gets or sets the amount the basic melee damage gets scaled with this value.
        /// </summary>
        public float MeleeDamageMultiplier { get; set; }

        /// <summary>
        /// Gets or sets the amount the basic weapon damage gets scaled with this value.
        /// </summary>
        public float WeaponDamageMultiplier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float PrecisionMultiplier { get; set; }

        /// <summary>
        /// Gets or sets the single use buffs that gets applied when reaching this level.
        /// </summary>
        public List<SingleUseBuff> SingleUseBuffs { get; set; }

        /// <summary>
        /// Gets or sets a value to <see cref="AgentModifier"/> combiner, that adds the value to the corresponding
        /// modifier, when this Level gets applied.
        /// </summary>
        /// <example>
        /// Player has Booster <see cref="AgentModifier.HealSupport"/> Value = 0.72f.
        /// We now have the entry <see cref="AgentModifier.HealSupport"/> value 0.1f.
        /// When this level gets applied those two values gets added togheter to 0.82f, and from now on the player heals more.
        /// </example>
        public Dictionary<AgentModifier, float> ValueToBoosterEffect { get; set; }
    }
}
