using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace ReportPortal.Cli
{
    public partial class Program
    {
        public static async Task<int> Main(string[] args, IConsole console = null)
        {
            var rpCommand = new RootCommand("Interact with Report Portal API");

            AddConnectCommand(rpCommand);
            AddLaunchCommand(rpCommand);

            var b = new CommandLineBuilder(rpCommand)
                .UseDefaults();
            var parser = b.Build();

            return await parser.InvokeAsync(args, console);
        }
    }
}
