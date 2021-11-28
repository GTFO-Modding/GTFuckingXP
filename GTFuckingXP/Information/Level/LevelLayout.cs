using System.Collections.Generic;

namespace GTFuckingXP.Information.Level
{
    /// <summary>
    /// Contains all levels
    /// </summary>
    public class LevelLayout
    {
        public LevelLayout(int id, List<Level> levels)
        {
            Id = id;
            Levels = levels;
        }

        /// <summary>
        /// Gets or sets the id leading to that 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets all levels containing in this layout.
        /// </summary>
        public List<Level> Levels { get; set; }
    }
}
