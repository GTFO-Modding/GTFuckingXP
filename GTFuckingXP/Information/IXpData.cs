using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTFuckingXP.Information
{
    /// <summary>
    /// Interface for handling xp calculations
    /// </summary>
    public interface IXpData
    {
        /// <summary>
        /// Gets or sets the xp gained by this instance.
        /// </summary>
        uint XpGain { get; set; }

        /// <summary>
        /// Gets or sets the xp gained by this instance while being in a debuff state.
        /// </summary>
        uint DebuffXp { get; set; }

        /// <summary>
        /// Gets or sets the amount of xp that gets subtracted for each level you currently are.
        /// Example: 
        /// <see cref="XpGain"/> is 20
        /// <see cref="LevelScalingXpDecrese"/> is 4
        /// Your current level is 4
        /// On receiving this XpData you gain <see cref="XpGain"/> - (<see cref="LevelScalingXpDecrese"/> * 4)
        /// which results into 4XP.
        /// </summary>
        int LevelScalingXpDecrese { get; set; }
    }
}
