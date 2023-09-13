namespace JLogger
{
    /// <summary>
    /// Logging levels.
    /// </summary>
    public enum LogLevel
    {
        INFO,
        WARNING,
        ERROR
    }

    /// <summary>
    /// Simple logger.
    /// </summary>
    public class JLog : IJLog
    {
        // Loggers
        private readonly FileLogger _fileLogger = new FileLogger();
        private readonly ConsoleLogger _consoleLogger = new ConsoleLogger();

        // Singleton ->
        private static JLog? _instance;
        private static readonly object lockObj = new object();

        public static JLog Instance 
        { 
            get 
            {
                lock (lockObj)
                {
                    if (_instance == null)
                    {
                        _instance = new JLog();
                    }
                    return _instance;
                }
            }
        }


        public Task LogAsync(LogLevel logLevel, string message, int code = 0)
        {
            _consoleLogger.LogAsync(logLevel, message, code);
            if (logLevel == LogLevel.WARNING || logLevel == LogLevel.ERROR)
            {
                return _fileLogger.LogAsync(logLevel, message, code);
            }
            else
            {
                return Task.Factory.StartNew(() => { return true; }); ;
            }
        }
    }
}
