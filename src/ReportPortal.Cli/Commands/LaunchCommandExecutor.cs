using ReportPortal.Cli.Http;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportPortal.Cli.Commands
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

            _console.Out.Write(launches.Items.First().Id.ToString());
        }
    }
}
