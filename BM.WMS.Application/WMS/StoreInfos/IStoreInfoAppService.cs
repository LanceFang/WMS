using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BM.WMS.Dto;
using BM.WMS.WMS.Warehouses.Dtos;

namespace BM.WMS.WMS.Warehouses
{
    /// <summary>
    /// 库房信息服务接口
    /// </summary>
    public interface IStoreInfoAppService : IApplicationService
    {
        #region 库房信息管理

        /// <summary>
        /// 根据查询条件获取库房信息分页列表
        /// </summary>
        Task<PagedResultOutput<StoreInfoListDto>> GetPagedStoreInfosAsync(GetStoreInfoInput input);

        /// <summary>
        /// 通过Id获取库房信息信息进行编辑或修改 
        /// </summary>
        Task<GetStoreInfoForEditOutput> GetStoreInfoForEditAsync(NullableIdDto<System.Guid> input);

        /// <summary>
        /// 通过指定id获取库房信息ListDto信息
        /// </summary>
        Task<StoreInfoListDto> GetStoreInfoByIdAsync(EntityDto<System.Guid> input);



        /// <summary>
        /// 新增或更改库房信息
        /// </summary>
        Task CreateOrUpdateStoreInfoAsync(CreateOrUpdateStoreInfoInput input);





        /// <summary>
        /// 新增库房信息
        /// </summary>
        Task<StoreInfoEditDto> CreateStoreInfoAsync(StoreInfoEditDto input);

        /// <summary>
        /// 更新库房信息
        /// </summary>
        Task UpdateStoreInfoAsync(StoreInfoEditDto input);

        /// <summary>
        /// 删除库房信息
        /// </summary>
        Task DeleteStoreInfoAsync(EntityDto<System.Guid> input);

        #endregion




    }
}
