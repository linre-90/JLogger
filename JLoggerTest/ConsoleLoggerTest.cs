using JLogger;

namespace JLoggerTest
{
    [TestClass]
    public class ConsoleLoggerTest
    {
        [TestMethod]
        public async Task LogCTestSmokeTest()
        {
            await JLog.Instance.LogAsync(LogLevel.WARNING, "Bad request", 400);
        }
    }
}