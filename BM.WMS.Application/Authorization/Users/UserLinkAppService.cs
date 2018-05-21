using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using Abp.UI;
using BM.WMS.Authorization.Users.Dto;
using BM.WMS.Dto;
using BM.WMS.MultiTenancy;

namespace BM.WMS.Authorization.Users
{
    [AbpAuthorize]
    public class UserLinkAppService : WMSAppServiceBase, IUserLinkAppService
    {
        private readonly AbpLoginResultTypeHelper _abpLoginResultTypeHelper;
        private readonly IUserLinkManager _userLinkManager;
        private readonly IRepository<Tenant> _tenantRepository;
        private readonly IRepository<UserAccount, long> _userAccountRepository;
        private readonly LogInManager _logInManager;

        public UserLinkAppService(
            AbpLoginResultTypeHelper abpLoginResultTypeHelper,
            IUserLinkManager userLinkManager,
            IRepository<Tenant> tenantRepository,
            IRepository<UserAccount, long> userAccountRepository,
            LogInManager logInManager)
        {
            _abpLoginResultTypeHelper = abpLoginResultTypeHelper;
            _userLinkManager = userLinkManager;
            _tenantRepository = tenantRepository;
            _userAccountRepository = userAccountRepository;
            _logInManager = logInManager;
        }

        public async Task LinkToUser(LinkToUserInput input)
        {
            using (UnitOfWorkManager.Current.DisableFilter(AbpDataFilters.MayHaveTenant))
            {
                var loginResult = await _logInManager.LoginAsync(input.UsernameOrEmailAddress, input.Password, input.TenancyName);

                if (loginResult.Result != AbpLoginResultType.Success)
                {
                    throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(loginResult.Result, input.UsernameOrEmailAddress, input.TenancyName);
                }

                if (loginResult.User.Id == AbpSession.GetUserId())
                {
                    throw new UserFriendlyException(L("YouCannotLinkToSameAccount"));
                }

                if (loginResult.User.ShouldChangePasswordOnNextLogin)
                {
                    throw new UserFriendlyException(L("ChangePasswordBeforeLinkToAnAccount"));
                }

                await _userLinkManager.Link(GetCurrentUser(), loginResult.User);
            }
        }

        public async Task<PagedResultOutput<LinkedUserDto>> GetLinkedUsers(GetLinkedUsersInput input)
        {
            var currentUserAccount = await _userLinkManager.GetUserAccountAsync(AbpSession.ToUserIdentifier());
            if (currentUserAccount == null)
            {
                return new PagedResultOutput<LinkedUserDto>(0, new List<LinkedUserDto>());
            }
            using (UnitOfWorkManager.Current.DisableFilter(AbpDataFilters.MayHaveTenant))
            {
                var query = CreateLinkedUsersQuery(currentUserAccount, input.Sorting)
                            .Skip(input.SkipCount)
                            .Take(input.MaxResultCount);

                var totalCount = await query.CountAsync();
                var linkedUsers = await query.ToListAsync();

                return new PagedResultOutput<LinkedUserDto>(
                    totalCount,
                    linkedUsers
                );
            }
        }

        public async Task<ListResultDto<LinkedUserDto>> GetRecentlyUsedLinkedUsers()
        {
            var currentUserAccount = await _userLinkManager.GetUserAccountAsync(AbpSession.ToUserIdentifier());
            if (currentUserAccount == null)
            {
                return new ListResultDto<LinkedUserDto>();
            }

            var query = CreateLinkedUsersQuery(currentUserAccount, "LastLoginTime DESC");
            var recentlyUsedlinkedUsers = await query.Skip(0).Take(3).ToListAsync();

            return new ListResultDto<LinkedUserDto>(recentlyUsedlinkedUsers);
        }

        public async Task UnlinkUser(UnlinkUserInput input)
        {
            var currentUserAccount = await _userLinkManager.GetUserAccountAsync(AbpSession.ToUserIdentifier());

            if (!currentUserAccount.UserLinkId.HasValue)
            {
                throw new ApplicationException(L("You are not linked to any account"));
            }

            if (!await _userLinkManager.AreUsersLinked(AbpSession.ToUserIdentifier(), input.ToUserIdentifier()))
            {
                return;
            }

            await _userLinkManager.Unlink(input.ToUserIdentifier());
        }

        private IQueryable<LinkedUserDto> CreateLinkedUsersQuery(UserAccount currentUserAccount, string sorting)
        {
            var currentUserIdentifier = AbpSession.ToUserIdentifier();
            return (from userAcount in _userAccountRepository.GetAll()
                    join tentant in _tenantRepository.GetAll() on userAcount.TenantId equals tentant.Id into TentantJoined
                    from tentant in TentantJoined.DefaultIfEmpty()
                    where (userAcount.TenantId != currentUserIdentifier.TenantId ||
                            userAcount.UserId != currentUserIdentifier.UserId) &&
                            userAcount.UserLinkId.HasValue &&
                            userAcount.UserLinkId == currentUserAccount.UserLinkId
                    select new LinkedUserDto
                    {
                        Id = userAcount.UserId,
                        TenantId = userAcount.TenantId,
                        TenancyName = tentant == null ? "." : tentant.TenancyName,
                        Username = userAcount.UserName,
                        LastLoginTime = userAcount.LastLoginTime
                    }).OrderBy(sorting);
        }

    }
}