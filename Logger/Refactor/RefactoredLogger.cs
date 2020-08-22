using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Refactor
{
    public interface ILogger
    {
        void Log(string logText);
    }

    public class FileLogger : ILogger
    {
        public void Log(string logText)
        {
            throw new NotImplementedException();
        }
    }

    public class EventLogger : ILogger
    {
        public void Log(string logText)
        {
            throw new NotImplementedException();
        }
    }

    public class LoggerContext
    {
        private ILogger _logger;

        public void SetLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(string logText)
        {
            _logger.Log(logText);
        }
    }

    public class LoggerFactory
    {
        public static ILogger CreateLogger(string whereToLog)
        {
            switch (whereToLog)
            {
                case "TEXTFILE":
                    return new FileLogger();
                    break;
                case "EVENTLOG":
                    return new EventLogger();
                    break;
                default:
                    throw new Exception("not Supported Log !!!!!");
            }
        }
    }
}
