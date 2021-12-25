namespace GTFuckingXP.Communication.Info
{
    public enum Commands
    {
        /// <summary>
        /// The command that gets sent when the dev tool wants the current GameState.
        /// </summary>
        AskForGameState,

        /// <summary>
        /// The command that gets sent when the plugin sends over the current GameState.
        /// </summary>
        SendingGameState,

        /// <summary>
        /// The command the dev tool sents whenever the plugin should restart all of the scripts and read the json files again.
        /// </summary>
        Reset,

        /// <summary>
        /// The command the dev tool sents when the plugin should add xp to the current xp count.
        /// </summary>
        GiveXp,

        /// <summary>
        /// The command the dev tool sents when the plugin should set the current level to the info count.
        /// </summary>
        SetLevel,

        /// <summary>
        /// The command that gets sent when the dev tool wants to know the path to the json files.
        /// </summary>
        AskForJsonDirectory,

        /// <summary>
        /// The command that gets send when the plugins send the dev tool the path to the json files.
        /// </summary>
        SendJsonDirectory

    }
}
