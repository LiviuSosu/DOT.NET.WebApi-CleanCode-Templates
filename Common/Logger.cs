using Serilog;
using Serilog.Events;
using System;

namespace Common
{
    public class Logger : ILogger
    {
        public Logger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(new Configuration().LoggingFilePath)
                .CreateLogger();
        }

        public void LogException(Exception exception, string actionName, string input)
        {
            Log.Logger.Error(string.Format("Occured exception {0} on {1} having the input: {2}", exception.Message, actionName, input), LogEventLevel.Error);
        }

        public void LogMessage(string methodName, string input, LogEventLevel logEventLevel)
        {
            Log.Logger.Information(string.Format("Logging on {0} with input {1}", methodName, input), LogEventLevel.Information);
        }
    }
}
