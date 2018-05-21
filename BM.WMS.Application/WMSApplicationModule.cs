using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using BM.WMS.Authorization;

namespace BM.WMS
{
    [DependsOn(typeof(WMSCoreModule), typeof(AbpAutoMapperModule))]
    public class WMSApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                //mapper.CreateMap<,>()

                CustomDtoMapper.CreateMappings(mapper);
            });
        }

        public override void Initialize()
        {
            //将当前程序集注册到依赖注入容器中
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
