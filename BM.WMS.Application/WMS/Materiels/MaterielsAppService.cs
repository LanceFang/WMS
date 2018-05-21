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
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using BM.WMS.Authorization;
using BM.WMS.Dto;
using BM.WMS.MaterielsManage.Dtos;
using Microsoft.AspNet.Identity;

namespace BM.WMS.MaterielsManage
{
    /// <summary>
    /// 物料表服务实现
    /// </summary>
    [AbpAuthorize(AppPermissions.Materiels)]
    public class MaterielsAppService : WMSAppServiceBase, IMaterielsAppService
    {
        private readonly IRepository<Materiels, System.Guid> _materielsRepository;

        private readonly MaterielsManage _materielsManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public MaterielsAppService(IRepository<Materiels, Guid> materielsRepository, MaterielsManage materielsManage)
        {
            _materielsRepository = materielsRepository;
            _materielsManage = materielsManage;
        }

        #region 物料表管理

        /// <summary>
        /// 根据查询条件获取物料表分页列表
        /// </summary>
        public async Task<PagedResultOutput<MaterielsListDto>> GetPagedMaterielssAsync(GetMaterielsInput input)
        {
            var query = _materielsRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件
            query = query.Include(i => i.MaterielsClass).WhereIf(!input.FilterText.IsNullOrWhiteSpace(),
               i => i.MaterialCode.Contains(input.FilterText) |
               i.MaterialName.Contains(input.FilterText)
           );
            var materielsCount = await query.CountAsync();

            var materielss = await query
            .OrderBy($"{input.sort} {input.order}")
            .PageBy(input)
            .ToListAsync();

            var materielsListDtos = materielss.MapTo<List<MaterielsListDto>>();
            return new PagedResultOutput<MaterielsListDto>(
            materielsCount,
            materielsListDtos
            );
        }

        /// <summary>
        /// 通过Id获取物料表信息进行编辑或修改 
        /// </summary>
        public async Task<GetMaterielsForEditOutput> GetMaterielsForEditAsync(NullableIdDto<System.Guid> input)
        {
            var output = new GetMaterielsForEditOutput();

            MaterielsEditDto materielsEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _materielsRepository.GetAsync(input.Id.Value);
                materielsEditDto = entity.MapTo<MaterielsEditDto>();
            }
            else
            {
                materielsEditDto = new MaterielsEditDto();
            }

            output.Materiels = materielsEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取物料表ListDto信息
        /// </summary>
        public async Task<MaterielsListDto> GetMaterielsByIdAsync(EntityDto<System.Guid> input)
        {
            var entity = await _materielsRepository.GetAsync(input.Id);

            return entity.MapTo<MaterielsListDto>();
        }

        /// <summary>
        /// 新增或更改物料表
        /// </summary>
        public async Task CreateOrUpdateMaterielsAsync(CreateOrUpdateMaterielsInput input)
        {
            if (input.MaterielsEditDto.Id.HasValue)
            {
                await UpdateMaterielsAsync(input.MaterielsEditDto);
            }
            else
            {
                await CreateMaterielsAsync(input.MaterielsEditDto);
            }
        }

        /// <summary>
        /// 新增物料表
        /// </summary>
        [AbpAuthorize(AppPermissions.Materiels_CreateMateriels)]
        public virtual async Task<MaterielsEditDto> CreateMaterielsAsync(MaterielsEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            CheckErrors(await CheckMaterielsCodeIsExsit(input.MaterialCode, string.Empty));

            var entity = input.MapTo<Materiels>();

            entity = await _materielsRepository.InsertAsync(entity);
            return entity.MapTo<MaterielsEditDto>();
        }

        public async Task<IdentityResult> CheckMaterielsCodeIsExsit(string materielsCode, string id)
        {
            var count = await _materielsRepository.GetAll()
                .WhereIf(!materielsCode.IsNullOrWhiteSpace(), i => i.MaterialCode == materielsCode)
                .WhereIf(AbpSession.TenantId.HasValue, i => i.TenantId == AbpSession.TenantId.Value)
                .WhereIf(!id.IsNullOrWhiteSpace(), i => i.Id.ToString() != id).CountAsync();
            if (count > 0)
            {
                return AbpIdentityResult.Failed(string.Format(L("MaterialCodeIsExsit"), materielsCode));
            }
            return AbpIdentityResult.Success;
        }

        /// <summary>
        /// 编辑物料表
        /// </summary>
        [AbpAuthorize(AppPermissions.Materiels_EditMateriels)]
        public virtual async Task UpdateMaterielsAsync(MaterielsEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            CheckErrors(await CheckMaterielsCodeIsExsit(input.MaterialCode, input.Id.ToString()));
            var entity = await _materielsRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _materielsRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除物料表
        /// </summary>
        [AbpAuthorize(AppPermissions.Materiels_DeleteMateriels)]
        public async Task DeleteMaterielsAsync(EntityDto<System.Guid> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _materielsRepository.DeleteAsync(input.Id);
        }

        #endregion

    }
}
