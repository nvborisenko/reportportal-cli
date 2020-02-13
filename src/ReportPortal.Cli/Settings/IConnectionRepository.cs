namespace ReportPortal.Cli.Settings
{
    interface IConnectionRepository
    {
        IConnectionInfo LoadConnectionInfo();

        void SaveConnectionInfo(IConnectionInfo connectionInfo);
    }
}
