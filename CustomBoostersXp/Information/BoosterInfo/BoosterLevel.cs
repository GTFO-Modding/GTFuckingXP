using System.Collections.Generic;

namespace CustomBoostersXp.Information.BoosterInfo
{
    public class BoosterLevel
    {
        public BoosterLevel(int levelNumber, Dictionary<AgentModifier, float> valueToBoosterEffects)
        {
            LevelNumber = levelNumber;
            ValueToBoosterEffects = valueToBoosterEffects;
        }

        /// <summary>
        /// Gets or sets the number this level represents.
        /// </summary>
        public int LevelNumber { get; set; }

        //TODO CustomEffects like lifesteal

        /// <summary>
        /// Gets or sets the values that each active AgentModifier has.
        /// </summary>
        public Dictionary<AgentModifier, float> ValueToBoosterEffects { get; set; }

        public static implicit operator BoosterLevel(GTFuckingXP.Information.NetworkingInfo.BoosterInfo boosterInfo)
        {
            var agentModifiers = System.Enum.GetValues(typeof(AgentModifier));
            Dictionary<AgentModifier, float> boosterValues = new Dictionary<AgentModifier, float>();
            var boosterInfos = boosterInfo.GetBoosterValues();
            for (int index = 0; index < agentModifiers.Length; index++)
            {
                if (boosterInfos[index] != 0f)
                {
                    var modifier = (AgentModifier)agentModifiers.GetValue(index);
                    boosterValues[modifier] = boosterInfos[index];
                }
            }

            return new BoosterLevel(0, boosterValues);
        }
    }
}
