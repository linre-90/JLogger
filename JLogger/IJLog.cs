
namespace JLogger
{
    internal interface IJLog
    {
        Task LogAsync(LogLevel logLevel, string message, int code = 0);
    }
}
