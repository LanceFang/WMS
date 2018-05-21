using System.Collections.Generic;
using BM.WMS.Authorization.Users.Dto;

namespace BM.WMS.Web.Areas.SystemInfo.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}