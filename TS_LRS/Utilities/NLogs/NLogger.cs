using TS_LRS.Utilities.NLogs.Interfaces;
using NLog;

namespace TS_LRS.Utilities.NLogs
{
    public class NLogger:ILog
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public NLogger()
        {

        }
        public void Information(string message)
        {
            logger.Info(message);
        }

        public void Warning(string message)
        {
            logger.Warn(message);
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }
    }
}
