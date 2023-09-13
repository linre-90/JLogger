
namespace JLogger
{
    /// <summary>
    /// Simple file logger.
    /// </summary>
    internal class FileLogger : Logger, IJLog
    {
        static readonly object _lock = new object();

        /// <summary>
        /// Log to file with option for waiting.
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task LogAsync(LogLevel logLevel, string message, int code = 0)
        {
            // Start logging threaded task.
            return Task.Factory.StartNew(() => {
                FileWorker(base.Format(logLevel, message, code));
            });
        }

        /// <summary>
        /// Worker for log entry addition.
        /// </summary>
        /// <param name="obj"></param>
        private static void FileWorker(object? obj)
        {
            if(obj != null)
            {
                lock (_lock)
                {
                    string line = (string)obj;
                    string folder = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.FullName;
                    string fileName = "errlogs.txt";
                    File.AppendAllText(Path.Combine(folder, fileName), (string)line + "\n");
                }
            }
        }
    }
}
