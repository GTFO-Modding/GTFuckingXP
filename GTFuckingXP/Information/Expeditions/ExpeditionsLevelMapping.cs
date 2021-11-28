namespace GTFuckingXP.Information.Expeditions
{
    /// <summary>
    /// Contains information to select a specific gtfo expedition.
    /// </summary>
    public class ExpeditionsLevelMapping
    {
        public ExpeditionsLevelMapping()
        {

        }

        public ExpeditionsLevelMapping(eRundownTier tier, int expeditionIndex, int levelLayoutId)
        { 
            Tier = tier;
            ExpeditionIndex = expeditionIndex;
            LevelLayoutId = levelLayoutId;
        }

        /// <summary>
        /// Gets or sets the tier of the focused, mission.
        /// </summary>
        public eRundownTier Tier { get; set; }

        /// <summary>
        /// Gets or sets the index of the specific mission you're targeting.
        /// </summary>
        public int ExpeditionIndex { get; set; }

        /// <summary>
        /// Gets or sets the id that leads to the <see cref="LevelLayout"/> layout.
        /// </summary>
        public int LevelLayoutId { get; set; }
    }
}
