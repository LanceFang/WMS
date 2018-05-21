namespace BM.WMS.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class storeinfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoreInfo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StoreCode = c.String(nullable: false),
                        StoreName = c.String(nullable: false),
                        StoreAddress = c.String(),
                        UserId = c.Int(nullable: false),
                        UserName = c.String(),
                        Remark = c.String(),
                        TenantId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        User_Id = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_StoreInfo_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_StoreInfo_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoreInfo", "User_Id", "dbo.AbpUsers");
            DropIndex("dbo.StoreInfo", new[] { "User_Id" });
            DropTable("dbo.StoreInfo",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_StoreInfo_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_StoreInfo_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
