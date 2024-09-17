using NLog;

namespace bleaf_test_automation.Utils
{
    public static class Logger
    {
        private static readonly NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public static void LogInfo(string message)
        {
            logger.Info(message);
        }

        public static void LogError(string message)
        {
            logger.Error(message);
        }

        public static void LogDebug(string message)
        {
            logger.Debug(message);
        }
    }
}