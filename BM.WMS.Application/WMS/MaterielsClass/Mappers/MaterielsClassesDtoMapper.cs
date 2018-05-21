using AutoMapper;
using BM.WMS.MaterielsClass.Dtos;

namespace BM.WMS.MaterielsClass.Mappers
{
    /// <summary>
    /// MaterielsClassesDto映射配置
    /// </summary>
    public class MaterielsClassesDtoMapper
    {
        private static volatile bool _mappedBefore;
        private static readonly object SyncObj = new object();

        /// <summary>
        /// 初始化映射
        /// </summary>
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            lock (SyncObj)
            {
                if (_mappedBefore)
                {
                    return;
                }
                CreateMappingsInternal(configuration);

                _mappedBefore = true;
            }
        }

        /// <summary>
        /// Configuration.Modules.AbpAutoMapper().Configurators.Add(MaterielsClassesDtoMapper.CreateMappings);
        /// 注入位置< see cref = "WMSApplicationModule" /> 
        /// <param name="configuration"></param>
        /// </summary>       
        private static void CreateMappingsInternal(IMapperConfigurationExpression configuration)
        {
            //默认ABP功能已经实现了，如果你要单独对DTO进行拓展，可以在此处放开注释文件。
            //Configuration.Modules.AbpAutoMapper().Configurators.Add(MaterielsClassesDtoMapper.CreateMappings);
            //Mapper.CreateMap<MaterielsClasses, MaterielsClassesEditDto>();
            //Mapper.CreateMap<MaterielsClasses, MaterielsClassesListDto>();
            //Mapper.CreateMap<MaterielsClassesEditDto, MaterielsClasses>();
            //Mapper.CreateMap<MaterielsClassesListDto, MaterielsClasses>();

        }
    }
}