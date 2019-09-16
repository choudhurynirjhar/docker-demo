using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Docker.Demo
{
    internal static class ContainerConfiguration
    {
        public static ServiceProvider Configure()
        {
            return new ServiceCollection()
                .AddLogging(l => l.AddConsole())
                .Configure<LoggerFilterOptions>(c => c.MinLevel = LogLevel.Trace)
                .AddSingleton<IPrintSettingsProvider, PrintSettingsProvider>()
                .AddSingleton<IConsolePrinter, ConsolePrinter>()
                .AddSingleton<ContinuousRunningProcessor>()
                .BuildServiceProvider();
        }
    }
}
