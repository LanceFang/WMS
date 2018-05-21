using Abp.Application.Services;
using BM.WMS.Tenants.Dashboard.Dto;

namespace BM.WMS.Tenants.Dashboard
{
    public interface ITenantDashboardAppService : IApplicationService
    {
        GetMemberActivityOutput GetMemberActivity();
    }
}
