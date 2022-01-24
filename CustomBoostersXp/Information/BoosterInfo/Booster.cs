using System.Collections.Generic;

namespace CustomBoostersXp.Information.BoosterInfo
{
    public class Booster
    {
        public Booster(BoosterImplantCategory category, string name, string customDEscription, List<int> usableForClassPersistentIds,
            List<BoosterLevel> boosterLevels)
        {
            Category = category;
            Name = name;
            UsableForClassPersistentIds = usableForClassPersistentIds;
            BoosterLevels = boosterLevels;
        }

        public BoosterImplantCategory Category { get; set; }
        public string Name { get; set; }
        public string CustomDescription { get; set; }
        public List<int> UsableForClassPersistentIds { get; set; }
        List<BoosterLevel> BoosterLevels { get; set; }
    }
}
