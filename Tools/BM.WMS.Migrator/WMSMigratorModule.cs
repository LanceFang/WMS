using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using BM.WMS.EntityFramework;

namespace BM.WMS.Migrator
{
    [DependsOn(typeof(WMSDataModule))]
    public class WMSMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<WMSDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}