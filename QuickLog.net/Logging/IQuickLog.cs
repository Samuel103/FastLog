namespace QuickLog.net.Logging;

public interface IQuickLog
{
    public void LogConsole(LogType logType, string message);
    
    public void LogFile(LogType logType, string message);
    public void Log(LogType logType, string message);

    public void LogTrace(string message);

    public void LogError(string message);

    public void LogError(Exception ex, string? message);
}