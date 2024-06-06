using GTFuckingXP.Information.NetworkingInfo;
using System.Collections.Generic;

namespace GTFuckingXP.Information.Level
{
    public class BoosterBuffs
    {
        public BoosterBuffs(int classLayoutPersistentId, List<int> activeLevels, Dictionary<AgentModifier, float>valueToBoosterEffects)
        {
            ClassLayoutPersistentId = classLayoutPersistentId;
            ActiveLevels = activeLevels;
            ValueToBoosterEffects = valueToBoosterEffects;
        }

        /// <summary>
        /// Gets or sets the persistendId that the active <see cref="LevelLayout"/> has.
        /// </summary>
        public int ClassLayoutPersistentId { get; set; }
        public List<int> ActiveLevels { get; set; }

        /// <summary>
        /// Gets or sets the values that each active AgentModifier has.
        /// </summary>
        public Dictionary<AgentModifier, float> ValueToBoosterEffects { get; set; }

        public static implicit operator BoosterBuffs(BoosterInfo boosterInfo)
        {
            var agentModifiers = System.Enum.GetValues(typeof(AgentModifier));
            Dictionary<AgentModifier, float> boosterValues = new Dictionary<AgentModifier, float>();
            var boosterInfos = boosterInfo.GetBoosterValues();
            for(int index = 0; index < agentModifiers.Length; index++)
            {
                if(boosterInfos[index] != 0f)
                {
                    var modifier = (AgentModifier)agentModifiers.GetValue(index);
                    boosterValues[modifier] = boosterInfos[index];
                }
            }

            return new BoosterBuffs(0, null, boosterValues);
        }
    }
}
