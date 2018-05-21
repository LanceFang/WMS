using Abp.AutoMapper;
using BM.WMS.Authorization.Users;
using BM.WMS.Authorization.Users.Dto;
using BM.WMS.Web.Areas.SystemInfo.Models.Common;

namespace BM.WMS.Web.Areas.SystemInfo.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; private set; }

        public UserPermissionsEditViewModel(GetUserPermissionsForEditOutput output, User user)
        {
            User = user;
            output.MapTo(this);
        }
    }
}