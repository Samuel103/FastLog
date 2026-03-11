using QuickLog.net;
using QuickLog.net.Logging;
using Microsoft.Extensions.DependencyInjection;
static class Program
{
	private static void Main()
	{
		var services = new ServiceCollection();

		services.AddQuickLog(options =>
		{
			options.EnableConsoleLogging = true;
			options.EnableFileLogging = true;
			options.FileLoggingPath = "Logs/exemple";
			options.AddDateToFileFormat = true;
		});
		services.AddTransient<App>();

		using var serviceProvider = services.BuildServiceProvider();

		var app = serviceProvider.GetRequiredService<App>();
		app.Run();
	}

    public class App{

		readonly IQuickLog _quickLog;
        public App(IQuickLog quickLog){
			_quickLog = quickLog;
        }

        public void Run(){
			_quickLog.LogTrace("Application started");
			_quickLog.LogError("This is a sample error log");
        }
    }
}

