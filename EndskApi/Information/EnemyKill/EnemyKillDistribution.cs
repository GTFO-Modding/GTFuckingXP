using EndskApi.Enums.EnemyKill;
using Enemies;
using Player;
using SNetwork;
using System.Collections.Generic;
using System.Linq;

namespace EndskApi.Information.EnemyKill
{
    /// <summary>
    /// Contains information about how much damage each player did to a <see cref="EnemyAgent"/>.
    /// </summary>
    public class EnemyKillDistribution
    {
        public EnemyKillDistribution(EnemyAgent agentToKill)
        {
            KilledEnemyAgent = agentToKill;
            DamageDistributions = new List<DamageDistribution>();
        }

        public EnemyAgent KilledEnemyAgent { get; set; }
        public List<DamageDistribution> DamageDistributions { get; set; }
        public PlayerAgent LastHitDealtBy { get; set; }
        public LastHitType lastHitType { get; set; }

        public void AddDamageDealtByPlayerAgent(PlayerAgent agent, float damage)
        {
            DamageDistributions.Add(new DamageDistribution(agent.PlayerSlotIndex, damage));
        }

        public float GetDamageDealtBySnet(SNet_Player player)
        {
            var slotIndex = player.PlayerSlotIndex();
            return DamageDistributions.Where(it => it.PlayerSlotIndex == slotIndex).Sum(it => it.DamageDealt);
        }
    }

    /// <summary>
    /// Contains information about damage dealt by a specific playeragent.
    /// </summary>
    public class DamageDistribution
    {
        public DamageDistribution(int slotIndex, float damage)
        {
            PlayerSlotIndex = slotIndex;
            DamageDealt = damage;
            
        }

        /// <summary>
        /// Gets or sets the <see cref="PlayerAgent.PlayerSlotIndex"/> that dealt <see cref="DamageDealt"/>.
        /// </summary>
        public int PlayerSlotIndex { get; set; }

        /// <summary>
        /// Gets or sets how much damage the player owning <see cref="SnetLookup"/> has dealt.
        /// </summary>
        public float DamageDealt { get; set; }
    }
}
