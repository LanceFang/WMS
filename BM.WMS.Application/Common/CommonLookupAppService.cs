using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.MultiTenancy;
using BM.WMS.Common.Dto;
using BM.WMS.Dto;
using BM.WMS.Editions;

namespace BM.WMS.Common
{
    [AbpAuthorize]
    public class CommonLookupAppService : WMSAppServiceBase, ICommonLookupAppService
    {
        private readonly EditionManager _editionManager;

        public CommonLookupAppService(EditionManager editionManager)
        {
            _editionManager = editionManager;
        }

        public async Task<ListResultDto<ComboboxItemDto>> GetEditionsForCombobox()
        {
            var editions = await _editionManager.Editions.ToListAsync();
            return new ListResultDto<ComboboxItemDto>(
                editions.Select(e => new ComboboxItemDto(e.Id.ToString(), e.DisplayName)).ToList()
                );
        }

        public async Task<PagedResultOutput<NameValueDto>> FindUsers(FindUsersInput input)
        {
            if (AbpSession.MultiTenancySide == MultiTenancySides.Host && input.TenantId.HasValue)
            {
                CurrentUnitOfWork.SetFilterParameter(AbpDataFilters.MayHaveTenant, AbpDataFilters.Parameters.TenantId, input.TenantId.Value);
            }

            var query = UserManager.Users
                .WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    u =>
                        u.Name.Contains(input.Filter) ||
                        u.Surname.Contains(input.Filter) ||
                        u.UserName.Contains(input.Filter) ||
                        u.EmailAddress.Contains(input.Filter)
                );

            var userCount = await query.CountAsync();
            var users = await query
                .OrderBy(u => u.Name)
                .ThenBy(u => u.Surname)
                .PageBy(input)
                .ToListAsync();

            var list = users.Select(u =>
                      new NameValueDto(
                          $"{u.UserName}|{u.Name} { u.Surname}({u.EmailAddress })",
                          u.Id.ToString()
                          )
                    ).ToList();

            return new PagedResultOutput<NameValueDto>(
                userCount,
                list
                );
        }
    }
}
