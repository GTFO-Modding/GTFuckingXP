using System.Collections.Generic;

namespace GTFuckingXP.Information.Level
{
    /// <summary>
    /// Contains all levels
    /// </summary>
    public class LevelLayout
    {
        public LevelLayout(int persistentId, string header, int groupPersistentId, string infoText, List<Level> levels)
        {
            PersistentId = persistentId;
            GroupPersistentId = groupPersistentId;
            Header = header;
            InfoText = infoText;
            Levels = levels;
        }

        /// <summary>
        /// Gets or sets the id leading to that 
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Gets or sets the name of the header, that is used in the scrollwindow of the loadoutpage.
        /// </summary>
        public int GroupPersistentId { get; set; }

        /// <summary>
        /// Gets or sets an unique id alongst all <see cref="LevelLayout"/>.
        /// </summary>
        public int PersistentId { get; set; }

        /// <summary>
        /// Gets or sets the info text for this class.
        /// </summary>
        public string InfoText { get; set; }

        ///// <summary>
        ///// Gets or sets all constant booster effects that does gets applied, when this <see cref="LevelLayout"/> is chosen.
        ///// </summary>
        //public Dictionary<AgentModifier, float> ConstantBoosterEffects { get; set; }

        /// <summary>
        /// Gets or sets all levels containing in this layout.
        /// </summary>
        public List<Level> Levels { get; set; }
    }
}
