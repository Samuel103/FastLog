using FastLog;
using FastLog.Logging;
using Microsoft.Extensions.DependencyInjection;
static class Program
{
	private static void Main()
	{
		var services = new ServiceCollection();

		services.AddFastLog(options =>
		{
			options.EnableConsoleLogging = true;
			options.EnableFileLogging = true;
			options.FileLoggingPath = "logs/fastlog.log";
		});
		services.AddTransient<App>();

		using var serviceProvider = services.BuildServiceProvider();

		var app = serviceProvider.GetRequiredService<App>();
		app.Run();
	}

    public class App{

		readonly IFastLog _fastLog;
        public App(IFastLog fastLog){
            _fastLog = fastLog;
        }

        public void Run(){
			_fastLog.LogTrace("Application started");
			_fastLog.LogError("This is a sample error log");
        }
    }
}

