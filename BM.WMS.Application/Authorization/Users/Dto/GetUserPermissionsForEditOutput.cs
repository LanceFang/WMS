using System.Collections.Generic;
using Abp.Application.Services.Dto;
using BM.WMS.Authorization.Dto;

namespace BM.WMS.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}