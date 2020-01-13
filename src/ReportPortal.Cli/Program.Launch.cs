using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Text;

namespace ReportPortal.Cli
{
    partial class Program
    {
        static void AddLaunchCommand(Command rootCommand)
        {
            var launchCommand = new Command("launch");

            rootCommand.Add(launchCommand);
        }
    }
}
