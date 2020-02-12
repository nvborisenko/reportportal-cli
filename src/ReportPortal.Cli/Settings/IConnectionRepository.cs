using System;
using System.Collections.Generic;
using System.Text;

namespace ReportPortal.Cli.Settings
{
    interface IConnectionRepository
    {
        IConnectionInfo LoadConnectionInfo();

        void SaveConnectionInfo(IConnectionInfo connectionInfo);
    }
}
