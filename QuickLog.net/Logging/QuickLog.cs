namespace QuickLog.net.Logging;

public class QuickLog : IQuickLog
{
    private readonly QuickLogOption _quickLogOption;

    public QuickLog(QuickLogOption options)
    {
        _quickLogOption = options;    
    }

    public void Log(LogType logType, string message)
    {
        if (_quickLogOption.EnableConsoleLogging ?? true)
        {
            LogConsole(logType, message);    
        }
        
        if (_quickLogOption.EnableFileLogging ?? false)
        {
            LogFile(logType,message);   
        }
    }

    public void LogConsole(LogType logType, string message)
    {
        Console.WriteLine("[{0}] [{1}] {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), logType.ToString(), message);
    }

    public void LogError(string message)
    {
        Log(LogType.Error, message);
    }

    public void LogError(Exception ex, string? message)
    {
        var details = string.IsNullOrWhiteSpace(message)
            ? ex.ToString()
            : $"{message} - {ex}";

        LogError(details);
    }

    public void LogFile(LogType logType, string message)
    {
        if (!(_quickLogOption.EnableFileLogging ?? false) || string.IsNullOrWhiteSpace(_quickLogOption.FileLoggingPath))
        {
            LogConsole(LogType.Error, "Error: either EnableFileLogging is set to false or FileLoggingPath is not set");
            return;
        }

        try
        {
            var filePath = _quickLogOption.FileLoggingPath! + (_quickLogOption.AddDateToFileFormat?? true? DateTime.Now.ToString("yyMMdd"):"") + ".log";
            var directory = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{logType}] {message}{Environment.NewLine}";
            File.AppendAllText(filePath, line);
        }
        catch (Exception ex)
        {
            LogConsole(LogType.Error, $"Unable to write log file: {ex.Message}");
        }
    }

    public void LogTrace(string message)
    {
        Log(LogType.Trace, message);
    }

}