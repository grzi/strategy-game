using System;
using System.IO;
using System.Text;

public static class GameLogger{

    public static string LOGS_DIR = @"Logs";
    private static FileStream m_FileStream;
    private static StreamWriter m_StreamWriter;


    public static void ConfigureLogging() {
        if (!Directory.Exists(LOGS_DIR)) { 
            Directory.CreateDirectory(LOGS_DIR);
        }
        PurgeLogs();
        string path = LOGS_DIR + "/strategy_" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + ".log";
        m_FileStream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.Read);
        m_StreamWriter = new StreamWriter(m_FileStream);
        m_StreamWriter.AutoFlush = true;

    }

    private static void PurgeLogs() {
        string[] files = Directory.GetFiles(LOGS_DIR);
        foreach (string filePath in files) {
            if (File.GetLastWriteTime(filePath) < DateTime.Now.AddDays(-3)) {
                File.Delete(filePath);
            }
        }
    }


    public static void Debug(string _message) {
        Log(LogLevel.DEBUG, _message);
    }

    public static void Info(string _message) {
        Log(LogLevel.INFO, _message);
    }

    public static void Warn(string _message) {
        Log(LogLevel.WARN, _message);
    }

    public static void Error(string _message) {
        Log(LogLevel.ERROR, _message);
    }

    private static void Log(LogLevel _logLevel, string _logMessage) {
        if (_logLevel >= GameController.Instance.Config.LogLevel) {
            if (GameController.Instance.Config.DevMode)
                UnityEngine.Debug.Log(_logMessage);
            StringBuilder builder = new StringBuilder(getDateTime());
            builder.Append(" - ");
            builder.Append(getLogLevelAsTxt(_logLevel));
            builder.Append(" : ");
            builder.Append(_logMessage);
            m_StreamWriter.WriteLine(builder.ToString());
        }

    }

    // Todo : Optimise this because we just build new string every time it's disgusting
    private static string getLogLevelAsTxt(LogLevel _logLevel) {
        string result = "[" + _logLevel.ToString() + "]";
        if (_logLevel == LogLevel.INFO || _logLevel == LogLevel.WARN) {
            result = " " + result;
        }
        return result;
    }

    public static string getDateTime() {
        return DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
    }

    public static void CloseLog() {
        m_StreamWriter.Close();
        m_FileStream.Close();
    }

    public enum LogLevel {
        DEBUG = 1, INFO = 2, WARN = 3, ERROR = 4
    }
}