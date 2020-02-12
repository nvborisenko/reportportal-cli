using Microsoft.Extensions.Configuration;
using System;

namespace ReportPortal.Cli.Settings
{
    class ConnectionInfo : IConnectionInfo
    {
        public ConnectionInfo(Uri server, string project, string token)
        {
            Server = server;
            Project = project;
            Token = token;
        }

        public Uri Server { get; }

        public string Project { get; }

        public string Token { get; }
    }
}
