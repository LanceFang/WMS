using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using BM.WMS.Authorization;
using BM.WMS.Authorization.Users;
using BM.WMS.Dto;
using BM.WMS.MaterielsClass.Dto;
using BM.WMS.MaterielsClass.Dtos;
using Microsoft.AspNet.Identity;
using Abp.UI;

namespace BM.WMS.MaterielsClass
{
    [AbpAuthorize(AppPermissions.MaterielsClasses)]
    public class MaterielsClassesAppService : WMSAppServiceBase, IMaterielsClassesAppService
    {
        //private readonly IRepository<MaterielsClasses, Guid> _materielsClassesRepository;
        //private readonly IRepository<User, long> _userRepository;

        //public MaterielsClassesAppService(IRepository<MaterielsClasses, Guid> materielsClassesRepository, IRepository<User, long> userRepository)
        //{
        //    _materielsClassesRepository = materielsClassesRepository;
        //    _userRepository = userRepository;
        //}

        //public async Task<PagedResultOutput<MaterielsClassesListDto>> GetMaterielsClasses(GetMaterielsClassesInputDto input)
        //{
        //    var query = _materielsClassesRepository.GetAll()
        //        .WhereIf(!input.ClassCode.IsNullOrWhiteSpace(), i => i.ClassCode.Contains(input.ClassCode))
        //        .WhereIf(!input.ClassName.IsNullOrWhiteSpace(), i => i.ClassName.Contains(input.ClassName));

        //    var resultCount = await query.CountAsync();
        //    var materielsClasses = await query
        //        .OrderBy($"{input.sort} {input.order}")
        //        .PageBy(input)
        //        .ToListAsync();

        //    var materielsClassesDtos = materielsClasses.MapTo<List<MaterielsClassesListDto>>();

        //    return new PagedResultOutput<MaterielsClassesListDto>(resultCount, materielsClassesDtos);
        //}

        //[AbpAuthorize(AppPermissions.Page_MaterielsManage_Classes_Create)]
        //public async Task CreateMaterielsClass(MaterielsClasses input)
        //{
        //    var materielsclass = new MaterielsClasses(AbpSession.TenantId.Value, input.ClassCode, input.ClassName);
        //    await _materielsClassesRepository.InsertAsync(input);
        //}

        private readonly IRepository<MaterielsClasses, System.Guid> _materielsClassesRepository;
        private readonly IMaterielsClassesListExcelExporter _materielsClassesListExcelExporter;


        private readonly MaterielsClassesManage _materielsClassesManage;
        /// <summary>
        /// 构造方法
        /// </summary>
        public MaterielsClassesAppService(IRepository<MaterielsClasses, System.Guid> materielsClassesRepository,
MaterielsClassesManage materielsClassesManage
      , IMaterielsClassesListExcelExporter materielsClassesListExcelExporter
  )
        {
            _materielsClassesRepository = materielsClassesRepository;
            _materielsClassesManage = materielsClassesManage;
            _materielsClassesListExcelExporter = materielsClassesListExcelExporter;
        }

        #region 物料分类管理

        /// <summary>
        /// 根据查询条件获取物料分类分页列表
        /// </summary>
        public async Task<PagedResultOutput<MaterielsClassesListDto>> GetPagedMaterielsClassessAsync(GetMaterielsClassesInput input)
        {
            var query = _materielsClassesRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件
            query = query.WhereIf(!input.FilterText.IsNullOrWhiteSpace(),
                i => i.ClassCode.Contains(input.FilterText) |
                i.ClassName.Contains(input.FilterText)
            );

            var materielsClassesCount = await query.CountAsync();

            var materielsClassess = await query
            .OrderBy($"{input.sort} {input.order}")
            .PageBy(input)
            .ToListAsync();

            var materielsClassesListDtos = materielsClassess.MapTo<List<MaterielsClassesListDto>>();
            return new PagedResultOutput<MaterielsClassesListDto>(
                materielsClassesCount,
                materielsClassesListDtos
            );
        }

        public async Task<PagedResultOutput<MaterielsClassesListDto>> GetSelectMaterielsClassessAsync(GetMaterielsClassesInput input)
        {
            var query = _materielsClassesRepository.GetAll().WhereIf(true, item => item.IsEnable == true);
            //TODO:根据传入的参数添加过滤条件
            query = query.WhereIf(!input.FilterText.IsNullOrWhiteSpace(),
                i => i.ClassCode.Contains(input.FilterText) |
                i.ClassName.Contains(input.FilterText)
            );

            var materielsClassesCount = await query.CountAsync();

            var materielsClassess = await query
            .OrderBy($"{input.sort} {input.order}")
            .PageBy(input)
            .ToListAsync();

            var materielsClassesListDtos = materielsClassess.MapTo<List<MaterielsClassesListDto>>();
            return new PagedResultOutput<MaterielsClassesListDto>(
                materielsClassesCount,
                materielsClassesListDtos
            );
        }

        /// <summary>
        /// 通过Id获取物料分类信息进行编辑或修改 
        /// </summary>
        public async Task<GetMaterielsClassesForEditOutput> GetMaterielsClassesForEditAsync(NullableIdDto<System.Guid> input)
        {
            var output = new GetMaterielsClassesForEditOutput();

            MaterielsClassesEditDto materielsClassesEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _materielsClassesRepository.GetAsync(input.Id.Value);
                materielsClassesEditDto = entity.MapTo<MaterielsClassesEditDto>();
            }
            else
            {
                materielsClassesEditDto = new MaterielsClassesEditDto();
            }

            output.MaterielsClasses = materielsClassesEditDto;
            return output;
        }

        /// <summary>
        /// 通过指定id获取物料分类ListDto信息
        /// </summary>
        public async Task<MaterielsClassesListDto> GetMaterielsClassesByIdAsync(EntityDto<System.Guid> input)
        {
            var entity = await _materielsClassesRepository.GetAsync(input.Id);

            return entity.MapTo<MaterielsClassesListDto>();
        }

        /// <summary>
        /// 新增或更改物料分类
        /// </summary>
        public async Task CreateOrUpdateMaterielsClassesAsync(CreateOrUpdateMaterielsClassesInput input)
        {
            if (input.MaterielsClassesEditDto.Id.HasValue)
            {
                await UpdateMaterielsClassesAsync(input.MaterielsClassesEditDto);
            }
            else
            {
                await CreateMaterielsClassesAsync(input.MaterielsClassesEditDto);
            }
        }

        /// <summary>
        /// 新增物料分类
        /// </summary>
        [AbpAuthorize(AppPermissions.MaterielsClasses_CreateMaterielsClasses)]
        public virtual async Task<MaterielsClassesEditDto> CreateMaterielsClassesAsync(MaterielsClassesEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            await CheckClassCodeIsExsit(input.ClassCode, string.Empty);

            var entity = input.MapTo<MaterielsClasses>();

            entity = await _materielsClassesRepository.InsertAsync(entity);
            return entity.MapTo<MaterielsClassesEditDto>();
        }

        /// <summary>
        /// 编辑物料分类
        /// </summary>
        [AbpAuthorize(AppPermissions.MaterielsClasses_EditMaterielsClasses)]
        public virtual async Task UpdateMaterielsClassesAsync(MaterielsClassesEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            await CheckClassCodeIsExsit(input.ClassCode, input.Id.Value.ToString());
            var entity = await _materielsClassesRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _materielsClassesRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除物料分类
        /// </summary>
        [AbpAuthorize(AppPermissions.MaterielsClasses_DeleteMaterielsClasses)]
        public async Task DeleteMaterielsClassesAsync(EntityDto<System.Guid> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            //已启用物料不允许删除
            await MaterielsIsEnable(input);
            await _materielsClassesRepository.DeleteAsync(input.Id);

        }

        /// <summary>
        /// 批量删除物料分类
        /// </summary>
        [AbpAuthorize(AppPermissions.MaterielsClasses_DeleteMaterielsClasses)]
        public async Task BatchDeleteMaterielsClassesAsync(List<System.Guid> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _materielsClassesRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        /// <summary>
        /// 分类编号不允许重复
        /// </summary>
        /// <param name="classCode"></param>
        /// <returns></returns>
        public async Task CheckClassCodeIsExsit(string classCode, string id)
        {
            var count = await _materielsClassesRepository.GetAll()
                .WhereIf(!classCode.IsNullOrWhiteSpace(), i => i.ClassCode == classCode)
                .WhereIf(AbpSession.TenantId.HasValue, i => i.TenantId == AbpSession.TenantId.Value)
                .WhereIf(!id.IsNullOrWhiteSpace(), i => i.Id.ToString() != id)
                .CountAsync();
            if (count > 0)
            {
                throw new UserFriendlyException(string.Format(L("ClassCodeIsExsit")));
            }
        }

        /// <summary>
        /// 已启用物料分类不允许删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task MaterielsIsEnable(EntityDto<System.Guid> input)
        {
            var entity = await _materielsClassesRepository.GetAsync(input.Id);
            if (entity != null)
            {
                if (entity.IsEnable)
                {
                    throw new UserFriendlyException(string.Format(L("MaterielsIsEnable")));
                }
            }
        }

        #endregion


        #region 物料分类的Excel导出功能


        public async Task<FileDto> GetMaterielsClassesToExcel()
        {
            var entities = await _materielsClassesRepository.GetAll().ToListAsync();
            var dtos = entities.MapTo<List<MaterielsClassesListDto>>();
            var fileDto = _materielsClassesListExcelExporter.ExportMaterielsClassesToFile(dtos);
            return fileDto;
        }


        #endregion

    }
}
