using GTFuckingXP.Information.Level;

namespace GTFuckingXP.Communication.Info
{
    /// <summary>
    /// Contains information that contain all xp progressions in the current game.
    /// </summary>
    public class GameState
    {
        public GameState(Level currentLevel, LevelLayout currentLeveLlayout, uint currentTotalXp)
        {
            CurrentLevel = currentLevel;
            CurrentLevelLayout = currentLeveLlayout;
            TotalXp = currentTotalXp;
        }

        /// <summary>
        /// Gets or sets the current level that is applied.
        /// </summary>
        public Level CurrentLevel { get; set; }

        /// <summary>
        /// Gets or sets the levellayout used at the moment.
        /// </summary>
        public LevelLayout CurrentLevelLayout { get; set;}

        /// <summary>
        /// Gets or sets the total xp.
        /// </summary>
        public uint TotalXp { get; set; }
    }
}
