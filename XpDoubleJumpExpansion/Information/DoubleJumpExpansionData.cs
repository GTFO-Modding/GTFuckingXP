using GTFuckingXP.Information.Level;
using System.Collections.Generic;

namespace XpDoubleJumpExpansion.Information
{
    public class DoubleJumpExpansionData
    {
        public DoubleJumpExpansionData(int levelLayoutPersistentId, List<int> activeOnLevels)
        {
            LevelLayoutPersistentId = levelLayoutPersistentId;
            ActiveOnLevels = activeOnLevels;
        }

        /// <summary>
        /// Gets or sets the persistend id of the <see cref="LevelLayout"/> that this data instance focused to.
        /// </summary>
        public int LevelLayoutPersistentId { get; set; }

        /// <summary>
        /// Gets or sets when the double jump is active.
        /// </summary>
        public List<int> ActiveOnLevels { get; set; }
    }
}
