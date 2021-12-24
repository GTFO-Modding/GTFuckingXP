using System.Collections.Generic;

namespace GTFuckingXP.Information.Level
{
    /// <summary>
    /// Contains all levels
    /// </summary>
    public class LevelLayout
    {
        public LevelLayout(string header, string infoText, List<Level> levels)
        {
            Header = header;
            InfoText = infoText;
            Levels = levels;
        }

        /// <summary>
        /// Gets or sets the id leading to that 
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Gets or sets the info text for this class.
        /// </summary>
        public string InfoText { get; set; }

        /// <summary>
        /// Gets or sets all levels containing in this layout.
        /// </summary>
        public List<Level> Levels { get; set; }
    }
}
