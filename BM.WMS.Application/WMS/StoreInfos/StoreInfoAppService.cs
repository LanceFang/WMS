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
using BM.WMS.Dto;
using BM.WMS.WMS.Warehouses.Dtos;

namespace BM.WMS.WMS.Warehouses
{
    /// <summary>
    /// 库房信息服务实现
    /// </summary>
    [AbpAuthorize(AppPermissions.StoreInfo)]
    public class StoreInfoAppService : WMSAppServiceBase, IStoreInfoAppService
    {
        private readonly IRepository<StoreInfo, System.Guid> _storeInfoRepository;

        private readonly StoreInfoManage _storeInfoManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public StoreInfoAppService(IRepository<StoreInfo, System.Guid> storeInfoRepository, StoreInfoManage storeInfoManage)
        {
            _storeInfoRepository = storeInfoRepository;
            _storeInfoManage = storeInfoManage;

        }

        #region 库房信息管理

        /// <summary>
        /// 根据查询条件获取库房信息分页列表
        /// </summary>
        public async Task<PagedResultOutput<StoreInfoListDto>> GetPagedStoreInfosAsync(GetStoreInfoInput input)
        {
            var query = _storeInfoRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件
            query = query.Include(i => i.User).WhereIf(!input.FilterText.IsNullOrWhiteSpace(),
           i => i.StoreCode.Contains(input.FilterText) |
           i.StoreName.Contains(input.FilterText));

            var storeInfoCount = await query.CountAsync();
            var storeInfos = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var storeInfoListDtos = storeInfos.MapTo<List<StoreInfoListDto>>();
            return new PagedResultOutput<StoreInfoListDto>(
            storeInfoCount,
            storeInfoListDtos
            );
        }

        /// <summary>
        /// 通过Id获取库房信息信息进行编辑或修改 
        /// </summary>
        public async Task<GetStoreInfoForEditOutput> GetStoreInfoForEditAsync(NullableIdDto<System.Guid> input)
        {
            var output = new GetStoreInfoForEditOutput();

            StoreInfoEditDto storeInfoEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _storeInfoRepository.GetAsync(input.Id.Value);
                storeInfoEditDto = entity.MapTo<StoreInfoEditDto>();
            }
            else
            {
                storeInfoEditDto = new StoreInfoEditDto();
            }

            output.StoreInfo = storeInfoEditDto;
            return output;
        }

        /// <summary>
        /// 通过指定id获取库房信息ListDto信息
        /// </summary>
        public async Task<StoreInfoListDto> GetStoreInfoByIdAsync(EntityDto<System.Guid> input)
        {
            var entity = await _storeInfoRepository.GetAsync(input.Id);

            return entity.MapTo<StoreInfoListDto>();
        }

        /// <summary>
        /// 新增或更改库房信息
        /// </summary>
        public async Task CreateOrUpdateStoreInfoAsync(CreateOrUpdateStoreInfoInput input)
        {
            if (input.StoreInfoEditDto.Id.HasValue)
            {
                await UpdateStoreInfoAsync(input.StoreInfoEditDto);
            }
            else
            {
                await CreateStoreInfoAsync(input.StoreInfoEditDto);
            }
        }

        /// <summary>
        /// 新增库房信息
        /// </summary>
        [AbpAuthorize(AppPermissions.StoreInfo_CreateStoreInfo)]
        public virtual async Task<StoreInfoEditDto> CreateStoreInfoAsync(StoreInfoEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<StoreInfo>();

            entity = await _storeInfoRepository.InsertAsync(entity);
            return entity.MapTo<StoreInfoEditDto>();
        }

        /// <summary>
        /// 编辑库房信息
        /// </summary>
        [AbpAuthorize(AppPermissions.StoreInfo_EditStoreInfo)]
        public virtual async Task UpdateStoreInfoAsync(StoreInfoEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _storeInfoRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _storeInfoRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除库房信息
        /// </summary>
        [AbpAuthorize(AppPermissions.StoreInfo_DeleteStoreInfo)]
        public async Task DeleteStoreInfoAsync(EntityDto<System.Guid> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _storeInfoRepository.DeleteAsync(input.Id);
        }

        #endregion












    }
}
