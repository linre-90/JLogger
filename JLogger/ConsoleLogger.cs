namespace JLogger
{
    /// <summary>
    /// Simple console logger.
    /// </summary>
    internal class ConsoleLogger : Logger, IJLog
    {
        public Task LogAsync(LogLevel logLevel, string message, int code = 0)
        {
            return Task.Factory.StartNew(() => { Console.WriteLine(base.Format(logLevel, message, code)); });
        }
    }
}
