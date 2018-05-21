using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BM.WMS.Dto;
using BM.WMS.MaterielsManage.Dtos;

namespace BM.WMS.MaterielsManage
{
    /// <summary>
    /// 物料表服务接口
    /// </summary>
    public interface IMaterielsAppService : IApplicationService
    {
        #region 物料表管理

        /// <summary>
        /// 根据查询条件获取物料表分页列表
        /// </summary>
        Task<PagedResultOutput<MaterielsListDto>> GetPagedMaterielssAsync(GetMaterielsInput input);

        /// <summary>
        /// 通过Id获取物料表信息进行编辑或修改 
        /// </summary>
        Task<GetMaterielsForEditOutput> GetMaterielsForEditAsync(NullableIdDto<System.Guid> input);

        /// <summary>
        /// 通过指定id获取物料表ListDto信息
        /// </summary>
        Task<MaterielsListDto> GetMaterielsByIdAsync(EntityDto<System.Guid> input);

        /// <summary>
        /// 新增或更改物料表
        /// </summary>
        Task CreateOrUpdateMaterielsAsync(CreateOrUpdateMaterielsInput input);

        /// <summary>
        /// 新增物料表
        /// </summary>
        Task<MaterielsEditDto> CreateMaterielsAsync(MaterielsEditDto input);

        /// <summary>
        /// 更新物料表
        /// </summary>
        Task UpdateMaterielsAsync(MaterielsEditDto input);

        /// <summary>
        /// 删除物料表
        /// </summary>
        Task DeleteMaterielsAsync(EntityDto<System.Guid> input);

        #endregion

    }
}
