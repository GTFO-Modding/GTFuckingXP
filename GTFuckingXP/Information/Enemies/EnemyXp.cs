namespace GTFuckingXP.Information.Enemies
{
    /// <summary>
    /// Information class that holds the xp data of an enemy.
    /// </summary>
    public class EnemyXp : IXpData
    {
        public EnemyXp()
        { }
        public EnemyXp(uint enemyId, string enemyName, uint killXp, uint debuffXp, int levelScalingXpDecrease)
        {
            EnemyId = enemyId;
            EnemyName = enemyName;
            XpGain = killXp;
            DebuffXp = debuffXp;
            LevelScalingXpDecrese = levelScalingXpDecrease;
        }

        /// <summary>
        /// Gets or sets the id that leads to a specific GTFO id.
        /// </summary>
        public uint EnemyId { get; set; }

        /// <summary>
        /// Gets or sets the enemy name that has <see cref="EnemyId"/> as their persistent id.
        /// </summary>
        public string EnemyName { get; set; }

        /// <summary>
        /// Gets or sets the xp gained by killing the enemy with the id <see cref="EnemyId"/>.
        /// </summary>
        public uint XpGain { get; set; }

        /// <summary>
        /// Gets or sets the xp gained by killing the enemy with the id <see cref="EnemyId"/> while being in a debuff phase.
        /// </summary>
        public uint DebuffXp { get; set; }

        /// <summary>
        /// Gets or sets the amount of xp that get subtracted each level you currently are.
        /// Example: 
        /// <see cref="XpGain"/> is 20
        /// <see cref="LevelScalingXpDecrese"/> is 4
        /// Your current level is 4
        /// On kill you gain <see cref="KillXp"/> - (<see cref="LevelScalingXpDecrese"/> * 4)
        /// which results into 4XP
        /// </summary>
        public int LevelScalingXpDecrese { get; set; }
        
    }
}
