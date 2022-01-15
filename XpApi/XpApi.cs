using GTFuckingXP.Information.Level;

namespace XpApi
{
    /// <summary>
    /// Contains documented xp api functions. 
    /// </summary>
    public static class XpApi
    {
        /// <summary>
        /// Reloads the entire xp data.
        /// </summary>
        /// <returns>If the new layout was applied ingame.</returns>
        public static bool ReloadData()
        {
            return GTFuckingXP.Communication.XpApi.ReloadData();
        }

        /// <summary>
        /// Adds <paramref name="xpAmount"/> to the current xp amount.
        /// </summary>
        /// <returns>If the current api call was successful.</returns>
        public static bool AddXp(uint xpAmount)
        {
            return GTFuckingXP.Communication.XpApi.AddXp(xpAmount);
        }

        /// <summary>
        /// Sets the current total xp to <paramref name="newTotalXpAmount"/>.<br/>
        /// WARNING: This call does not support backwards leveling! Which will cause problems, like a buggy xp bar.<br/>
        /// For lowering levels you may use <see cref="SetCurrentLevel(int, out int)"/>!
        /// </summary>
        /// <returns>If the call was successful.</returns>
        public static bool SetCurrentTotalXp(uint newTotalXpAmount, out int cheatedXp)
        {
            return GTFuckingXP.Communication.XpApi.SetCurrentTotalXp(newTotalXpAmount, out cheatedXp);
        }

        /// <summary>
        /// Sets the current level to <paramref name="levelNumber"/>.
        /// </summary>
        /// <returns>If the call was successful.</returns>
        public static bool SetCurrentLevel(int levelNumber, out int cheatedXp)
        {
            return GTFuckingXP.Communication.XpApi.SetCurrentLevel(levelNumber, out cheatedXp);
        }

        /// <summary>
        /// Changes the level class of the player to the <see cref="LevelLayout"/> where <see cref="LevelLayout.Header"/> is the same as <paramref name="header"/>.
        /// </summary>
        /// <param name="header">The header of the new levelLayout.</param>
        /// <returns>If the api call was successful.</returns>
        public static bool ChangeCurrentLevelLayout(string header)
        {
            return GTFuckingXP.Communication.XpApi.ChangeCurrentLevelLayout(header);
        }

        /// <summary>
        /// Changes the level class of the player to the <paramref name="newActiveLevelLayout"/>. <br/>
        /// This call may give yourself some xp depending on if the level 1 in the other levellayout only needs 150XP but now needs 400XP which will just 
        /// </summary>
        /// <param name="newActiveLevelLayout">The new <see cref="LevelLayout"/> that should be applied.</param>
        /// <returns>If the api call was successful.</returns>
        public static bool ChangeCurrentLevelLayout(LevelLayout newActiveLevelLayout)
        {
            return GTFuckingXP.Communication.XpApi.ChangeCurrentLevelLayout(newActiveLevelLayout);
        }

        //TODO Callback Handler unter einem level up/down aufrufen.
        ///// <summary>
        ///// Whenever the player changes their current level <paramref name="callback"/> will be called with the new level.
        ///// </summary>
        ///// <param name="callback">An action that takes the newLevel as parameter.</param>
        ///// <returns>If the api call was successful.</returns>
        //public static bool AddLevelChangedCallback(Action<Level> callback)
        //{
        //    return false;
        //}
    }
}
