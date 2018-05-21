using System.Threading.Tasks;
using Abp.Application.Services;
using BM.WMS.Roles.Dto;

namespace BM.WMS.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
