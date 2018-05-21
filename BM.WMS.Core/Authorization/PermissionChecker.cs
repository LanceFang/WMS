using Abp.Authorization;
using BM.WMS.Authorization.Roles;
using BM.WMS.Authorization.Users;
using BM.WMS.MultiTenancy;

namespace BM.WMS.Authorization
{
    /// <summary>
    /// Implements <see cref="PermissionChecker"/>.
    /// </summary>
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
