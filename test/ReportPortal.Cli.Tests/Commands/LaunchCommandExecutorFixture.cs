using FluentAssertions;
using Moq;
using ReportPortal.Cli.Commands.Launch;
using ReportPortal.Cli.Http;
using ReportPortal.Client.Abstractions.Responses;
using System;
using System.Collections.Generic;
using System.CommandLine.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ReportPortal.Cli.Tests.Commands
{
    public class LaunchCommandExecutorFixture
    {
        [Fact]
        public async Task GetLaunches()
        {
            var console = new TestConsole();
            var service = new Mock<IApiClient>();
            service.Setup(s => s.GetLaunchesAsync()).ReturnsAsync(new Content<LaunchResponse>() { Items = new List<LaunchResponse>() });
            var executer = new LaunchCommandExecutor(service.Object, console);
            await executer.GetLaunches();
            console.Out.ToString().Should().Contain("ID");
        }
    }
}
