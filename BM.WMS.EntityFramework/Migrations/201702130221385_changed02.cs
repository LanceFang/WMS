namespace BM.WMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Diagnostics;
    using EntityFramework;

    public partial class changed02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppBinaryObjects",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Bytes = c.Binary(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            //Configuration configuration = new Configuration();
            //configuration.ContextType = typeof(WMSDbContext);
            //var migrator = new DbMigrator(configuration);

            ////This will get the SQL script which will update the DB and write it to debug
            //var scriptor = new MigratorScriptingDecorator(migrator);
            //string script = scriptor.ScriptUpdate(sourceMigration: null, targetMigration: null).ToString();
            //Debug.Write(script);

            ////This will run the migration update script and will run Seed() method
            //migrator.Update();
        }

        public override void Down()
        {
            DropTable("dbo.AppBinaryObjects");
        }
    }
}
