using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace GTFuckingXP.Information.Level
{
    /// <summary>
    /// Contains information to be read as an individual level
    /// </summary>
    public class Level
    {
        public Level()
        { }

        public Level(int levelNumber, uint totalXp, float healthMultiplier, float meleeMultiplier, float weaponMultiplier)
        {
            LevelNumber = levelNumber;
            TotalXpRequired = totalXp;

            HealthMultiplier = healthMultiplier;
            MeleeDamageMultiplier = meleeMultiplier;
            WeaponDamageMultiplier = weaponMultiplier;
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
    }
}
