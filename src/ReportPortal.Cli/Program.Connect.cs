using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using ReportPortal.Cli.Settings;
using Microsoft.Extensions.DependencyInjection;
using ReportPortal.Cli.Http;
using System.Threading.Tasks;

namespace ReportPortal.Cli
{
    partial class Program
    {
        static void AddConnectCommand(Command rootCommand)
        {
            var connectCommand = new Command("connect", "Connects this tool with Report Portal API")
            {
                new Option(new string[]{ "--server", "-s" }, "API endpoint e.g. http://<host>:<port>/api/v1")
                {
                    Argument = new Argument<Uri>(),
                    Required = true
                },
                new Option(new string[]{ "--project", "-p" }, "Project to interact with")
                {
                    Argument = new Argument<string>(),
                    Required = true
                },
                new Option(new string[]{ "--token", "-t" }, "User identifier token")
                {
                    Argument = new Argument<string>(),
                    Required = true
                }
            };

            connectCommand.Handler = CommandHandler.Create<Uri, string, string>((s, p, t) => Connect(s, p, t));

            rootCommand.AddCommand(connectCommand);
        }

        static async Task Connect(Uri server, string project, string token)
        {
            var console = _serviceProvider.GetService<IConsole>();

            var connectionInfo = new ConnectionInfo(server, project, token);

            var apiClient = new ApiClient(connectionInfo);
            var user = await apiClient.GetCurrentUserAsync();
            console.Out.Write($"Welcome, {user.Fullname}!");


            var connectionInfoRepository = _serviceProvider.GetService<IConnectionRepository>();

            connectionInfoRepository.SaveConnectionInfo(connectionInfo);
        }
    }
}
