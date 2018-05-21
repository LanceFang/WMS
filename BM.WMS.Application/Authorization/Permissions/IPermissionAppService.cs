using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BM.WMS.Authorization.Permissions.Dto;

namespace BM.WMS.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
