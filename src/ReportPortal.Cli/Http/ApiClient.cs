using ReportPortal.Cli.Settings;
using ReportPortal.Client;
using ReportPortal.Client.Abstractions.Responses;
using System;
using System.Threading.Tasks;

namespace ReportPortal.Cli.Http
{
    class ApiClient : IApiClient
    {
        private Service _service;

        public ApiClient(IConnectionInfo connectionInfo)
        {
            _service = new Service(connectionInfo.Server, connectionInfo.Project, connectionInfo.Token);
        }

        public ApiClient(IConnectionRepository connectionRepository)
        {
            var connectionInfo = connectionRepository.LoadConnectionInfo();
            _service = new Service(connectionInfo.Server, connectionInfo.Project, connectionInfo.Token);
        }

        public async Task<UserResponse> GetCurrentUserAsync()
        {
            return await _service.User.GetAsync();
        }

        public async Task<Content<LaunchResponse>> GetLaunchesAsync()
        {
            return await _service.Launch.GetAsync();
        }
    }
}
