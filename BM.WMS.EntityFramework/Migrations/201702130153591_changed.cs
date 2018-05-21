namespace BM.WMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbpUsers", "ProfilePictureId", c => c.Guid());
            AddColumn("dbo.AbpUsers", "ShouldChangePasswordOnNextLogin", c => c.Boolean(nullable: false));
            AddColumn("dbo.AbpUsers", "UserLinkId", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AbpUsers", "UserLinkId");
            DropColumn("dbo.AbpUsers", "ShouldChangePasswordOnNextLogin");
            DropColumn("dbo.AbpUsers", "ProfilePictureId");
        }
    }
}
