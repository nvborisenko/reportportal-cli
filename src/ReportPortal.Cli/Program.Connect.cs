using System;
using System.CommandLine;
using System.Collections.Generic;
using System.Text;
using System.CommandLine.Invocation;

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

        static void Connect(Uri server, string project, string token)
        {
            Console.WriteLine($"S: {server}, P: {project}, T: {token}");
        }
    }
}
