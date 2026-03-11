namespace QuickLog.net;

public class QuickLogOption
{
    public bool? EnableConsoleLogging {get; set;}
    public bool? EnableFileLogging {get;set;}
    public bool? AddDateToFileFormat {get;set;}
    public string? FileLoggingPath {get;set;}
}