namespace BM.WMS.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class MaterielsClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaterielsClasses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClassCode = c.String(nullable: false, maxLength: 8),
                        ClassName = c.String(nullable: false),
                        TenantId = c.Int(),
                        Remark = c.String(),
                        IsEnable = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_MaterielsClasses_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_MaterielsClasses_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MaterielsClasses",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_MaterielsClasses_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_MaterielsClasses_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
