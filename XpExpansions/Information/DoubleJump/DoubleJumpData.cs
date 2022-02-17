namespace XpExpansions.Information.DoubleJump
{
    internal class DoubleJumpData
    {
        public DoubleJumpData(int levelLayoutPersistentId, int unlockAtLevel)
        {
            LevelLayoutPersistentId = levelLayoutPersistentId;
            UnlockAtLevel = unlockAtLevel;
        }

        /// <summary>
        /// Gets or sets the persistend id of the <see cref="LevelLayout"/> that this data instance focused to.
        /// </summary>
        public int LevelLayoutPersistentId { get; set; }

        /// <summary>
        /// Gets or sets when the double jump is active.
        /// </summary>
        public int UnlockAtLevel { get; set; }
    }
}
