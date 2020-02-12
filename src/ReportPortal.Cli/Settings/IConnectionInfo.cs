using System;
using System.Collections.Generic;
using System.Text;

namespace ReportPortal.Cli.Settings
{
    interface IConnectionInfo
    {
        Uri Server { get; }

        string Project { get; }

        string Token { get; }
    }
}
