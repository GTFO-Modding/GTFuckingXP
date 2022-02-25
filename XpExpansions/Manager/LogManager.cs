using BepInEx.Logging;

namespace XpExpansions.Manager
{
    public static class LogManager
    {
        private static ManualLogSource logger;
        internal static bool _debugMessagesActive;

        internal static void SetLogger(ManualLogSource log)
        {
            logger = log;
            Logger.Sources.Add(logger);
        }

        public static void Verbose(object msg)
        {
            if (_debugMessagesActive)
                logger.LogInfo(msg);
        }

        public static void Debug(object msg)
        {
            if (_debugMessagesActive)
                logger.LogDebug(msg);
        }

        public static void Message(object msg)
        {
            if (_debugMessagesActive)
                logger.LogMessage(msg);
        }

        public static void Error(object msg)
        {
            logger.LogError(msg);
        }

        public static void Warn(object msg)
        {
            logger.LogWarning(msg);
        }
    }
}
