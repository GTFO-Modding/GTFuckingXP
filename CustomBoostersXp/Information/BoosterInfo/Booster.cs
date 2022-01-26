using System.Collections.Generic;

namespace CustomBoostersXp.Information.BoosterInfo
{
    public class Booster
    {
        public Booster(BoosterImplantCategory category, string name, string customDescription, List<int> usableForClassPersistentIds,
            List<BoosterLevel> boosterLevels)
        {
            Category = category;
            Name = name;
            CustomDescription = customDescription;
            UsableForClassPersistentIds = usableForClassPersistentIds;
            BoosterLevels = boosterLevels;
        }

        /// <summary>
        /// Gets or sets the unique id of all <see cref="Booster"/> instances.
        /// </summary>
        public uint PersistentId { get; set; }
        public BoosterImplantCategory Category { get; set; }
        public string Name { get; set; }
        public string CustomDescription { get; set; }
        public List<int> UsableForClassPersistentIds { get; set; }
        public List<BoosterLevel> BoosterLevels { get; set; }
    }
}
