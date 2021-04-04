using System;

namespace Common
{
    public interface ILogger
    {
        void LogException(Exception exception, string actionName, string input);

        void LogWarning(string methodName, string input);

        void LogInformation(string methodName, string input);
    }
}
