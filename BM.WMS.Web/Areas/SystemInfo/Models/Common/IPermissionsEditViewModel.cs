using System.Collections.Generic;
using BM.WMS.Authorization.Dto;

namespace BM.WMS.Web.Areas.SystemInfo.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}