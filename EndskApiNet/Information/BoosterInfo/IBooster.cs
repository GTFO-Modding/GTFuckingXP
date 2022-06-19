using EndskApi.Enums.Booster;
using System.Collections.Generic;

namespace EndskApi.Information.BoosterInfo
{
    public interface IBooster
    {
        //TODO
        /// <summary>
        /// Gets or sets where this instance of booster should be placed.
        /// </summary>
         object Category { get; set; }

         List<BoosterEffect> BoosterEffects { get; set; }
         List<BoosterCondition> BoosterConditions { get; set; }
    }
}
