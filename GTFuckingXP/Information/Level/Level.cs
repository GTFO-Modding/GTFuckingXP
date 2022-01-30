using GTFuckingXP.Information.NetworkingInfo;
using System.Collections.Generic;
using System.Text.Json;

namespace GTFuckingXP.Information.Level
{
    /// <summary>
    /// Contains information to be read as an individual level
    /// </summary>
    public class Level
    {
        public Level()
        { }

        public Level(LevelReachedInfo levelData) : this(levelData.LevelNumber, 0, levelData.HealthMultiplier, 0f, 0f,
                null, JsonSerializer.Deserialize<List<CustomScalingBuff>>(levelData.CustomScaling))
        { }

        public Level(int levelNumber, uint totalXp, float healthMultiplier, float meleeMultiplier, float weaponMultiplier, List<SingleUseBuff> singleUseBuffs,
            List<CustomScalingBuff> customScaling, string customLevelUpPopupText = "", string customLevelStatsText = "")
        {
            LevelNumber = levelNumber;
            TotalXpRequired = totalXp;

            HealthMultiplier = healthMultiplier;
            MeleeDamageMultiplier = meleeMultiplier;
            WeaponDamageMultiplier = weaponMultiplier;
            LevelUpBonus = singleUseBuffs;

            CustomScaling = customScaling;
            CustomLevelStatsText = customLevelStatsText;
            CustomLevelUpPopupText = customLevelUpPopupText;
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
        /// Gets or sets the custom level reached popup text.
        /// </summary>
        public string CustomLevelUpPopupText { get; set; }

        /// <summary>
        /// Gets or sets the custom levelstats the player sees at the bottom right ingame.
        /// </summary>
        public string CustomLevelStatsText { get; set; }

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

        //public float PrecisionMultiplier { get; set; }

        /// <summary>
        /// Gets or sets all customscaling options
        /// </summary>
        public List<CustomScalingBuff> CustomScaling { get; set; }

        /// <summary>
        /// Gets or sets the single use buffs that gets applied when reaching this level.
        /// </summary>
        public List<SingleUseBuff> LevelUpBonus { get; set; }
    }
}
