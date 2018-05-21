using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using BM.WMS.Authorization.Roles;
using BM.WMS.MultiTenancy;

namespace BM.WMS.Authorization.Users
{
    /// <summary>
    /// User store.
    /// Used to perform database operations for <see cref="UserManager"/>.
    /// Extends <see cref="AbpUserStore{TTenant,TRole,TUser}"/>.
    /// </summary>
    public class UserStore : AbpUserStore<Role, User>
    {
        public UserStore(
            IRepository<User, long> userRepository,
            IRepository<UserLogin, long> userLoginRepository,
            IRepository<UserRole, long> userRoleRepository,
            IRepository<Role> roleRepository,
            IRepository<UserPermissionSetting, long> userPermissionSettingRepository,
            IUnitOfWorkManager unitOfWorkManager,
            IRepository<UserClaim, long> userclaim
            )
            : base(
                userRepository,
                userLoginRepository,
                userRoleRepository,
                roleRepository,
                userPermissionSettingRepository,
                unitOfWorkManager,
                userclaim
            )
        {
        }
    }
}