using System.CommandLine.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace ReportPortal.Cli.Tests.MainMethod
{
    public class MainMethodTests
    {
        [Fact]
        public async Task Should_Output_Usage_Without_Commands()
        {
            var console = new TestConsole();
            var exitCode = await Program.Main(null, console);

            exitCode.Should().NotBe(0);
            console.Out.ToString().Should().Contain("Usage");
        }
    }
}