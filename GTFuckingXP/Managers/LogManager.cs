using BepInEx.Logging;

namespace GTFuckingXP.Managers
{
    public class LogManager
    {
        private static readonly ManualLogSource logger;
        private static readonly bool _debugMessagesActive;
        static LogManager()
        {
            _debugMessagesActive = BepInExLoader.DebugMessages.Value;
            logger = new ManualLogSource(BepInExLoader.MODNAME);
            Logger.Sources.Add(logger);
        }

        public static void Log(object msg)
        {
            if (_debugMessagesActive)
                Message(msg);
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
