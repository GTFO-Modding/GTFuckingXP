using BepInEx.Logging;

namespace GTFuckingXP.Managers
{
    public class LogManager
    {
        private static readonly ManualLogSource logger;
        static LogManager()
        {
            logger = new ManualLogSource(BepInExLoader.MODNAME);
            Logger.Sources.Add(logger);
        }

        public static void Log(object msg)
        {
            Message(msg);
        }

        public static void Verbose(object msg)
        {
            logger.LogInfo(msg);
        }

        public static void Debug(object msg)
        {
            logger.LogDebug(msg);
        }

        public static void Message(object msg)
        {
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
