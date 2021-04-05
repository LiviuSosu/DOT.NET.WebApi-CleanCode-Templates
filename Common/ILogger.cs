using Serilog.Events;
using System;

namespace Common
{
    public interface ILogger
    {
        void LogException(Exception exception, string actionName, string input);

        void LogMessage(string methodName, string input, LogEventLevel logEventLevel);
    }
}
