using System;

namespace Common
{
    public interface ILogger
    {
        void LogException(Exception exception, string actionName, string input);
    }
}
