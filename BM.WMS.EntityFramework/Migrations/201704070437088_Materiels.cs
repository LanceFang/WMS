namespace BM.WMS.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Materiels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Materiels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MaterialClassID = c.Guid(nullable: false),
                        TenantId = c.Int(),
                        ShortCode = c.String(),
                        MaterialCode = c.String(nullable: false, maxLength: 8),
                        MaterialName = c.String(nullable: false),
                        FullName = c.String(),
                        HelperCode = c.String(),
                        Model = c.String(nullable: false),
                        Unit = c.String(),
                        Remark = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        MaterielsClass_Id = c.Guid(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Materiels_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Materiels_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaterielsClasses", t => t.MaterielsClass_Id)
                .Index(t => t.MaterielsClass_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Materiels", "MaterielsClass_Id", "dbo.MaterielsClasses");
            DropIndex("dbo.Materiels", new[] { "MaterielsClass_Id" });
            DropTable("dbo.Materiels",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Materiels_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Materiels_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
