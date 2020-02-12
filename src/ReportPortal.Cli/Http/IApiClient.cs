using ReportPortal.Client.Abstractions.Responses;
using System.Threading.Tasks;

namespace ReportPortal.Cli.Http
{
    interface IApiClient
    {
        Task<UserResponse> GetCurrentUserAsync();

        Task<Content<LaunchResponse>> GetLaunchesAsync();
    }
}
