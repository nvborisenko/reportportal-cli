using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;

namespace ReportPortal.Cli.Settings
{
    class ConnectionRepository : IConnectionRepository
    {
        public static string HomeConfigFile
        {
            get
            {
                var filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var homeDir = Directory.CreateDirectory(Path.Combine(filePath, "ReportPortalCli"));
                var fullPath = Path.Combine(homeDir.FullName, "config.json");
                return fullPath;
            }
        }

        private IConfigurationRoot _configurationRoot;

        public ConnectionRepository(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }

        public IConnectionInfo LoadConnectionInfo()
        {
            var server = _configurationRoot.GetValue<Uri>("Server");
            var project = _configurationRoot.GetValue<string>("Project");
            var token = _configurationRoot.GetValue<string>("Token");
            return new ConnectionInfo(server, project, token);
        }

        public void SaveConnectionInfo(IConnectionInfo connectionInfo)
        {
            var fileContent = JsonConvert.SerializeObject(connectionInfo, Formatting.Indented);
            File.WriteAllText(HomeConfigFile, fileContent);
        }
    }
}
