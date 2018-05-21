using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using BM.WMS.EntityFramework;
using BM.WMS.Migrations.Seed;
using BM.WMS.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace BM.WMS.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<WMSDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WMS";
        }

        protected override void Seed(EntityFramework.WMSDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                //new DefaultTenantCreator(context).Create();
                //new TenantRoleAndUserBuilder(context, 1).Create();

                new DefaultTenantRoleAndUserCreator(context).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
