

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using BM.WMS.Authorization;
using BM.WMS.Customerses.Dtos;
using BM.WMS.Dto;

namespace BM.WMS.Customerses
{
    /// <summary>
    /// 客户资料管理服务实现
    /// </summary>
    [AbpAuthorize(AppPermissions.Customers)]
    public class CustomersAppService : WMSAppServiceBase, ICustomersAppService
    {
        private readonly IRepository<Customers, System.Guid> _customersRepository;
        private readonly ICustomersListExcelExporter _customersListExcelExporter;


        private readonly CustomersManage _customersManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public CustomersAppService(IRepository<Customers, System.Guid> customersRepository,
CustomersManage customersManage
      , ICustomersListExcelExporter customersListExcelExporter
  )
        {
            _customersRepository = customersRepository;
            _customersManage = customersManage;
            _customersListExcelExporter = customersListExcelExporter;
        }

        #region 客户资料管理管理

        /// <summary>
        /// 根据查询条件获取客户资料管理分页列表
        /// </summary>
        public async Task<PagedResultDto<CustomersListDto>> GetPagedCustomerssAsync(GetCustomersInput input)
        {

            var query = _customersRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件

            var customersCount = await query.CountAsync();

            var customerss = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var customersListDtos = customerss.MapTo<List<CustomersListDto>>();
            return new PagedResultDto<CustomersListDto>(
            customersCount,
            customersListDtos
            );
        }

        /// <summary>
        /// 通过Id获取客户资料管理信息进行编辑或修改 
        /// </summary>
        public async Task<GetCustomersForEditOutput> GetCustomersForEditAsync(NullableIdDto<System.Guid> input)
        {
            var output = new GetCustomersForEditOutput();

            CustomersEditDto customersEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _customersRepository.GetAsync(input.Id.Value);
                customersEditDto = entity.MapTo<CustomersEditDto>();
            }
            else
            {
                customersEditDto = new CustomersEditDto();
            }

            output.Customers = customersEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取客户资料管理ListDto信息
        /// </summary>
        public async Task<CustomersListDto> GetCustomersByIdAsync(EntityDto<System.Guid> input)
        {
            var entity = await _customersRepository.GetAsync(input.Id);

            return entity.MapTo<CustomersListDto>();
        }

        /// <summary>
        /// 新增或更改客户资料管理
        /// </summary>
        public async Task CreateOrUpdateCustomersAsync(CreateOrUpdateCustomersInput input)
        {
            if (input.CustomersEditDto.Id.HasValue)
            {
                await UpdateCustomersAsync(input.CustomersEditDto);
            }
            else
            {
                await CreateCustomersAsync(input.CustomersEditDto);
            }
        }

        /// <summary>
        /// 新增客户资料管理
        /// </summary>
        [AbpAuthorize(AppPermissions.Customers_CreateCustomers)]
        public virtual async Task<CustomersEditDto> CreateCustomersAsync(CustomersEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Customers>();

            entity = await _customersRepository.InsertAsync(entity);
            return entity.MapTo<CustomersEditDto>();
        }

        /// <summary>
        /// 编辑客户资料管理
        /// </summary>
        [AbpAuthorize(AppPermissions.Customers_EditCustomers)]
        public virtual async Task UpdateCustomersAsync(CustomersEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _customersRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _customersRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除客户资料管理
        /// </summary>
        [AbpAuthorize(AppPermissions.Customers_DeleteCustomers)]
        public async Task DeleteCustomersAsync(EntityDto<System.Guid> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _customersRepository.DeleteAsync(input.Id);
        }

        #endregion


        #region 客户资料管理的Excel导出功能


        public async Task<FileDto> GetCustomersToExcel()
        {
            var entities = await _customersRepository.GetAll().ToListAsync();

            var dtos = entities.MapTo<List<CustomersListDto>>();

            var fileDto = _customersListExcelExporter.ExportCustomersToFile(dtos);



            return fileDto;
        }

        #endregion

    }
}
