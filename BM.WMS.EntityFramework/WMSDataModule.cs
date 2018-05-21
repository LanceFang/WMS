using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using BM.WMS.EntityFramework;

namespace BM.WMS
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(WMSCoreModule))]
    public class WMSDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<WMSDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
            //Configuration.DefaultNameOrConnectionString = @"Data Source=LANCE-PC\MSSQLSERVER2008;Initial Catalog=WMS;Persist Security Info=True;User ID=sa;Password=pass123;";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
