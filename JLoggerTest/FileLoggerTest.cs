using JLogger;


namespace JLoggerTest
{
    [TestClass]
    public class FileLoggerTest
    {
        private string _folder = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.FullName;
        private string _fileName = "errlogs.txt";

        [TestMethod]
        public async Task FileLoggerSmokeTest()
        {
            await JLog.Instance.LogAsync(LogLevel.INFO, "Testing");
        }

        [TestMethod]
        public async Task FileLoggerFileExists()
        {
            await JLog.Instance.LogAsync(LogLevel.ERROR, "electric bugaloo", 6);
            bool fileExists = File.Exists(Path.Combine(_folder, _fileName));
            Assert.IsTrue(fileExists);
        }

        [TestMethod]
        public async Task FileLoggerFileContainsLine ()
        {
            await JLog.Instance.LogAsync(LogLevel.ERROR, "electric bugaloo with sauna", 6);
            string[] fileExists = File.ReadAllLines(Path.Combine(_folder, _fileName));
            Assert.IsTrue(fileExists.Any(e => e.Contains("electric bugaloo with sauna")));
        }

        [TestMethod]
        public async Task FileLoggerFileDoesNotLogInfo()
        {
            await JLog.Instance.LogAsync(LogLevel.INFO, "Missing bugaloo with sauna", 6);
            string[] fileExists = File.ReadAllLines(Path.Combine(_folder, _fileName));
            Assert.IsFalse(fileExists.Any(e => e.Contains("Missing bugaloo with sauna")));
        }

        [TestMethod]
        public void FileLoggerContinuousLogging()
        {
            // This test requires manual log file inspection!
            // Log file should contain 10 "Continuous bugaloo with sauna" warning logs in random order.
            for (int i = 0; i < 10; i++)
            {
                JLog.Instance.LogAsync(LogLevel.WARNING, "Continuous bugaloo with sauna", i + 1);
            }
            Assert.IsTrue(true);
        }
    }
}
