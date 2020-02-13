using ReportPortal.Cli.Formatters;
using ReportPortal.Cli.Http;
using ReportPortal.Client.Abstractions.Responses;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Rendering;
using System.CommandLine.Rendering.Views;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportPortal.Cli.Commands.Launch
{
    class LaunchCommandExecutor
    {
        private IApiClient _apiClient;
        private IConsole _console;

        public LaunchCommandExecutor(IApiClient apiClient, IConsole console)
        {
            _apiClient = apiClient;
            _console = console;
        }

        public async Task GetLaunches()
        {
            var launches = await _apiClient.GetLaunchesAsync();

            var tableView = new TableView<LaunchResponse>();
            tableView.Items = launches.Items.ToList();

            tableView.AddColumn(l => l.Uuid, new ContentView("ID"));
            tableView.AddColumn(l => l.Name, "NAME");

            var renderer = new ConsoleRenderer(_console);
            tableView.Render(renderer, new Region(0, 0, tableView.Measure(renderer, new Size(100, 100))));
        }
    }
}
