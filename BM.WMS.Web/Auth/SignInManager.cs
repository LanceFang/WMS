using System;
using Abp.Authorization;
using Abp.Configuration;
using Abp.Domain.Uow;
using Microsoft.Owin.Security;
using BM.WMS.Authorization.Roles;
using BM.WMS.Authorization.Users;
using BM.WMS.MultiTenancy;

namespace BM.WMS.Web.Auth
{
    public class SignInManager : AbpSignInManager<Tenant, Role, User>
    {
        public SignInManager(
            UserManager userManager,
            IAuthenticationManager authenticationManager,
            ISettingManager settingManager,
            IUnitOfWorkManager unitOfWorkManager)
            : base(
                  userManager,
                  authenticationManager,
                  settingManager,
                  unitOfWorkManager)
        {
        }
    }
}