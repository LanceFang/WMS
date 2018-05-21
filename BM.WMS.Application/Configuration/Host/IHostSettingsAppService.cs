using System.Threading.Tasks;
using Abp.Application.Services;
using BM.WMS.Configuration.Host.Dto;

namespace BM.WMS.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
