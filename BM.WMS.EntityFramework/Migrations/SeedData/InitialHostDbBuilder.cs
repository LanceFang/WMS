using BM.WMS.EntityFramework;
using EntityFramework.DynamicFilters;

namespace BM.WMS.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly WMSDbContext _context;

        public InitialHostDbBuilder(WMSDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            //new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
