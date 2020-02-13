using System;

namespace ReportPortal.Cli.Settings
{
    interface IConnectionInfo
    {
        Uri Server { get; }

        string Project { get; }

        string Token { get; }
    }
}
