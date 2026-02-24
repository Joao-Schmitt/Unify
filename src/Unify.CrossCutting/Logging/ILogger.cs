using System;

namespace Unify.CrossCutting.Logging
{
    public interface ILogger
    {
        void Write(string message, LogLevel level = LogLevel.Info, Exception ex = null);
    }
}
