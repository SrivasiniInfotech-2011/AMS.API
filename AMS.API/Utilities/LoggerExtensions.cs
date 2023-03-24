using System;
using Microsoft.Extensions.Logging;

namespace AMS.API.Utilities
{
    public static class LoggerExtensions
    {
        public static void Log<T>(this ILogger<T> logger, LogLevel logLevel, Exception exception, string message, params object[] args)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                    logger.LogTrace(exception, message, args);
                    break;
                case LogLevel.Debug:
                    logger.LogDebug(exception, message, args);
                    break;
                case LogLevel.Information:
                    logger.LogInformation(exception, message, args);
                    break;
                case LogLevel.Warning:
                    logger.LogWarning(exception, message, args);
                    break;
                case LogLevel.Error:
                    logger.LogError(exception, message, args);
                    break;
                case LogLevel.Critical:
                    logger.LogCritical(exception, message, args);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }
        }
    }
}
