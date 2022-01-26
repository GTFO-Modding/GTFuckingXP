using CustomBoostersXp.Information.BoosterInfo;
using System.Collections.Generic;

namespace CustomBoostersXp.Information
{
    public static class DefaultBoosterData
    {
        public static List<Booster> GetDefaultBoosters()
        {
            var boosters = new List<Booster>();

            var regenCapLevels = new List<BoosterLevel>()
            {
            new BoosterLevel(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 },
                new Dictionary<AgentModifier, float>() { { AgentModifier.RegenerationCap, 5f } }, 
                new Dictionary<BoosterImplants.BoosterCondition, float>())
            };
            var kamikazeRegenerationCap = new Booster(BoosterImplantCategory.Aggressive, "Regen",
                "CustomDescription...", new List<int>() { 4 }, regenCapLevels);

            boosters.Add(kamikazeRegenerationCap);


            //TODO Default Booster
            return boosters;
        }
    }
}
