using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using BM.WMS.Authorization.Roles;
using BM.WMS.Authorization.Users;
using BM.WMS.MultiTenancy;
using BM.WMS.Storage;
using BM.WMS.MaterielsClass;
using BM.WMS.MaterielsManage;
using BM.WMS.EntityFramework.EntityMapper.Materielses;
using BM.WMS.EntityFramework.EntityMapper.MaterielsClass;
using BM.WMS.WMS.Warehouses;
using BM.WMS.Customerses;

namespace BM.WMS.EntityFramework
{
    public class WMSDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public virtual IDbSet<BinaryObject> BinaryObjects { get; set; }

        public virtual IDbSet<MaterielsClasses> MaterielsClasses { get; set; }

        public IDbSet<Materiels> Materielss { get; set; }

        public IDbSet<StoreInfo> StoreInfos { get; set; }

        public IDbSet<Customers> Customerss { get; set; }
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public WMSDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in WMSDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of WMSDbContext since ABP automatically handles it.
         */
        public WMSDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public WMSDbContext(DbConnection connection)
            : base(connection, true)
        {

        }

        public WMSDbContext(DbConnection connection, bool contextOwnsConnection) : base(connection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MaterielsClassesCfg());
            modelBuilder.Configurations.Add(new MaterielsCfg());
            base.OnModelCreating(modelBuilder);
        }
    }
}
