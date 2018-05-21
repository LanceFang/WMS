using System.Linq;
using BM.WMS.EntityFramework;
using BM.WMS.MultiTenancy;

namespace BM.WMS.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly WMSDbContext _context;

        public DefaultTenantCreator(WMSDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
