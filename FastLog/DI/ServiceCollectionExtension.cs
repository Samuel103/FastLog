using FastLog.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace FastLog;

public static class FastLogExtension
{
    public static IServiceCollection AddFastLog(this IServiceCollection services, Action<FastLogOption> configure)
    {
        var options = new FastLogOption();
        configure(options);

        services.AddSingleton(options);
        services.AddSingleton<IFastLog, FastLog.Logging.FastLog>();

        return services;
    }
}