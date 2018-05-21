namespace BM.WMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AbpUsers", "UserLinkId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AbpUsers", "UserLinkId", c => c.Long());
        }
    }
}
