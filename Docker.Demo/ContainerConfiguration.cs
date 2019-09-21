using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Docker.Demo
{
    internal static class ContainerConfiguration
    {
        public static IServiceProvider Configure()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(l => l.AddConsole())
                .Configure<LoggerFilterOptions>(c => c.MinLevel = LogLevel.Trace);

            var containerBuilder = new ContainerBuilder();

            containerBuilder.Populate(serviceCollection);

            containerBuilder.RegisterType<PrintSettingsProvider>().As<IPrintSettingsProvider>().SingleInstance();
            containerBuilder.RegisterType<ConsolePrinter>().As<IConsolePrinter>().SingleInstance();
            containerBuilder.RegisterType<ContinuousRunningProcessor>().SingleInstance();

            var container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
        }
    }
}
