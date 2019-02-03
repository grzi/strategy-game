using NUnit.Framework;
using System.IO;

namespace Tests
{
    public class LoggerTests {
        [Test]
        public void ConfigureLogging_ShouldCreateDirectoryIfNotExist() {
            try {
                var files = Directory.GetFiles(GameLogger.LOGS_DIR);
                foreach (string file in files) {
                    File.Delete(file);
                }
                Directory.Delete(GameLogger.LOGS_DIR);
            }
            catch (DirectoryNotFoundException) {
                // It's ok
            }

            GameLogger.ConfigureLogging();
            Assert.AreEqual(true, Directory.Exists(@"Logs"));
            GameLogger.CloseLog();
        }

        [Test]
        public void ConfigureLogging_ShouldDeleteOldLogs() {
            var test = File.Create(GameLogger.LOGS_DIR + "/" + "4days_old.log");
            test.Close();
            File.SetLastWriteTime(GameLogger.LOGS_DIR + "/" + "4days_old.log", System.DateTime.Now.AddDays(-4));

            var test2 = File.Create(GameLogger.LOGS_DIR + "/" + "2days_old.log");
            test2.Close();
            File.SetLastWriteTime(GameLogger.LOGS_DIR + "/" + "2days_old.log", System.DateTime.Now.AddDays(-2));

            var test3 = File.Create(GameLogger.LOGS_DIR + "/" + "5days_old.log");
            test3.Close();
            File.SetLastWriteTime(GameLogger.LOGS_DIR + "/" + "5days_old.log", System.DateTime.Now.AddDays(-5));

            GameLogger.ConfigureLogging();

            var files = Directory.GetFiles(GameLogger.LOGS_DIR);

            Assert.AreEqual(2, files.Length);
            Assert.Contains(GameLogger.LOGS_DIR + "\\" + "2days_old.log", files);
            GameLogger.CloseLog();
        }
        
    }
}
