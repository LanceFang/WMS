using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BM.WMS.Dto;
using BM.WMS.MaterielsClass.Dtos;

namespace BM.WMS.MaterielsClass
{
    public interface IMaterielsClassesAppService : IApplicationService
    {
        #region 物料分类管理

        /// <summary>
        /// 根据查询条件获取物料分类分页列表
        /// </summary>
        Task<PagedResultOutput<MaterielsClassesListDto>> GetPagedMaterielsClassessAsync(GetMaterielsClassesInput input);

        /// <summary>
        /// 获取物料分类选用
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultOutput<MaterielsClassesListDto>> GetSelectMaterielsClassessAsync(GetMaterielsClassesInput input);

        /// <summary>
        /// 通过Id获取物料分类信息进行编辑或修改 
        /// </summary>
        Task<GetMaterielsClassesForEditOutput> GetMaterielsClassesForEditAsync(NullableIdDto<System.Guid> input);


        /// <summary>
        /// 通过指定id获取物料分类ListDto信息
        /// </summary>
        Task<MaterielsClassesListDto> GetMaterielsClassesByIdAsync(EntityDto<System.Guid> input);

        /// <summary>
        /// 新增或更改物料分类
        /// </summary>
        Task CreateOrUpdateMaterielsClassesAsync(CreateOrUpdateMaterielsClassesInput input);

        /// <summary>
        /// 新增物料分类
        /// </summary>
        Task<MaterielsClassesEditDto> CreateMaterielsClassesAsync(MaterielsClassesEditDto input);

        /// <summary>
        /// 更新物料分类
        /// </summary>
        Task UpdateMaterielsClassesAsync(MaterielsClassesEditDto input);

        /// <summary>
        /// 删除物料分类
        /// </summary>
        Task DeleteMaterielsClassesAsync(EntityDto<System.Guid> input);

        /// <summary>
        /// 批量删除物料分类
        /// </summary>
        Task BatchDeleteMaterielsClassesAsync(List<System.Guid> input);

        #endregion

        #region Excel导出功能

        /// <summary>
        /// 获取物料分类信息转换为Excel
        /// </summary>
        /// <returns></returns>
        Task<FileDto> GetMaterielsClassesToExcel();

        #endregion

    }
}
