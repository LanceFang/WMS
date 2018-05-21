using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BM.WMS.Customerses.Dtos;
using BM.WMS.Dto;

namespace BM.WMS.Customerses
{
    /// <summary>
    /// 客户资料管理服务接口
    /// </summary>
    public interface ICustomersAppService : IApplicationService
    {
        #region 客户资料管理管理

        /// <summary>
        /// 根据查询条件获取客户资料管理分页列表
        /// </summary>
        Task<PagedResultDto<CustomersListDto>> GetPagedCustomerssAsync(GetCustomersInput input);

        /// <summary>
        /// 通过Id获取客户资料管理信息进行编辑或修改 
        /// </summary>
        Task<GetCustomersForEditOutput> GetCustomersForEditAsync(NullableIdDto<System.Guid> input);

        /// <summary>
        /// 通过指定id获取客户资料管理ListDto信息
        /// </summary>
        Task<CustomersListDto> GetCustomersByIdAsync(EntityDto<System.Guid> input);

        /// <summary>
        /// 新增或更改客户资料管理
        /// </summary>
        Task CreateOrUpdateCustomersAsync(CreateOrUpdateCustomersInput input);

        /// <summary>
        /// 新增客户资料管理
        /// </summary>
        Task<CustomersEditDto> CreateCustomersAsync(CustomersEditDto input);

        /// <summary>
        /// 更新客户资料管理
        /// </summary>
        Task UpdateCustomersAsync(CustomersEditDto input);

        /// <summary>
        /// 删除客户资料管理
        /// </summary>
        Task DeleteCustomersAsync(EntityDto<System.Guid> input);

        #endregion

        #region Excel导出功能



        /// <summary>
        /// 获取客户资料管理信息转换为Excel
        /// </summary>
        /// <returns></returns>
        Task<FileDto> GetCustomersToExcel();

        #endregion

    }
}
