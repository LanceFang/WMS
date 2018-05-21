using System.Threading.Tasks;
using Abp.Application.Services;
using BM.WMS.Configuration.Tenants.Dto;

namespace BM.WMS.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);
    }
}
