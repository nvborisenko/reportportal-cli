using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace ReportPortal.Cli
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var rpCommand = new RootCommand("Interact with Report Portal API");

            AddConnectCommand(rpCommand);
            AddLaunchCommand(rpCommand);

            rpCommand.InvokeAsync(args);
        }
    }
}
