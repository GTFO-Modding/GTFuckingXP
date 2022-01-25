using EndskApi.Enums.Booster;
using System.Collections.Generic;

namespace EndskApi.Information.BoosterInfo
{
    public interface IBooster
    {
        /// <summary>
        /// Gets or sets where this instance of booster should be placed.
        /// </summary>
         BoosterCategory Category { get; set; }

         List<BoosterEffect> BoosterEffects { get; set; }
         List<BoosterCondition> BoosterConditions { get; set; }
    }
}
