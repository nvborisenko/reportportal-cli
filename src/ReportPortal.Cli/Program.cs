using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.CommandLine;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly:InternalsVisibleTo("ReportPortal.Cli.Tests")]

namespace ReportPortal.Cli
{
    partial class Program
    {
        static IServiceProvider _serviceProvider;

        public static async Task<int> Main(string[] args, IConsole console = null)
        {
            ConfigureServices(console);

            var rpCommand = new RootCommand("Interact with Report Portal API");

            AddConnectCommand(rpCommand);
            AddLaunchCommand(rpCommand);

            return await rpCommand.InvokeAsync(args, console);
        }

        static void ConfigureServices(IConsole console)
        {
            var serviceCollection = new ServiceCollection();

            var builder = new ConfigurationBuilder()
                .AddJsonFile(Settings.ConnectionRepository.HomeConfigFile, optional: true)
                .AddEnvironmentVariables("ReportPortal_Cli_");
            var configuration = builder.Build();

            serviceCollection.AddSingleton(console);
            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddScoped<Settings.IConnectionRepository, Settings.ConnectionRepository>();

            serviceCollection.AddSingleton<Http.IApiClient, Http.ApiClient>();

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
