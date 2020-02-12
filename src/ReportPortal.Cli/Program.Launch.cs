using System.CommandLine;
using System.CommandLine.Invocation;
using Microsoft.Extensions.DependencyInjection;
using ReportPortal.Cli.Commands;

namespace ReportPortal.Cli
{
    partial class Program
    {
        static void AddLaunchCommand(Command rootCommand)
        {
            var launchCommand = new Command("launch");

            launchCommand.Handler = CommandHandler.Create(() => _serviceProvider.GetRequiredService<LaunchCommandExecutor>().GetLaunches());

            rootCommand.Add(launchCommand);
        }
    }
}
