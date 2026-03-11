using QuickLog.net.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace QuickLog.net;

public static class QuickLogExtension
{
    public static IServiceCollection AddQuickLog(this IServiceCollection services, Action<QuickLogOption> configure)
    {
        var options = new QuickLogOption();
        configure(options);

        services.AddSingleton(options);
        services.AddSingleton<IQuickLog, QuickLog.net.Logging.QuickLog>();

        return services;
    }
}