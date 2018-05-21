namespace BM.WMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Materielsupdate : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Materiels", newSchema: "Basic");
            DropForeignKey("dbo.Materiels", "MaterielsClass_Id", "dbo.MaterielsClasses");
            DropIndex("Basic.Materiels", new[] { "MaterielsClass_Id" });
            DropColumn("Basic.Materiels", "MaterialClassID");
            RenameColumn(table: "Basic.Materiels", name: "MaterielsClass_Id", newName: "MaterialClassId");
            AddColumn("Basic.Materiels", "ClassName", c => c.String());
            AlterColumn("Basic.Materiels", "ShortCode", c => c.String(maxLength: 50));
            AlterColumn("Basic.Materiels", "MaterialCode", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("Basic.Materiels", "MaterialName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("Basic.Materiels", "FullName", c => c.String(maxLength: 100));
            AlterColumn("Basic.Materiels", "HelperCode", c => c.String(maxLength: 50));
            AlterColumn("Basic.Materiels", "Model", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("Basic.Materiels", "Unit", c => c.String(maxLength: 50));
            AlterColumn("Basic.Materiels", "Remark", c => c.String(maxLength: 200));
            AlterColumn("Basic.Materiels", "MaterialClassId", c => c.Guid(nullable: false));
            CreateIndex("Basic.Materiels", "MaterialClassId");
            AddForeignKey("Basic.Materiels", "MaterialClassId", "dbo.MaterielsClasses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Basic.Materiels", "MaterialClassId", "dbo.MaterielsClasses");
            DropIndex("Basic.Materiels", new[] { "MaterialClassId" });
            AlterColumn("Basic.Materiels", "MaterialClassId", c => c.Guid());
            AlterColumn("Basic.Materiels", "Remark", c => c.String());
            AlterColumn("Basic.Materiels", "Unit", c => c.String());
            AlterColumn("Basic.Materiels", "Model", c => c.String(nullable: false));
            AlterColumn("Basic.Materiels", "HelperCode", c => c.String());
            AlterColumn("Basic.Materiels", "FullName", c => c.String());
            AlterColumn("Basic.Materiels", "MaterialName", c => c.String(nullable: false));
            AlterColumn("Basic.Materiels", "MaterialCode", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("Basic.Materiels", "ShortCode", c => c.String());
            DropColumn("Basic.Materiels", "ClassName");
            RenameColumn(table: "Basic.Materiels", name: "MaterialClassId", newName: "MaterielsClass_Id");
            AddColumn("Basic.Materiels", "MaterialClassID", c => c.Guid(nullable: false));
            CreateIndex("Basic.Materiels", "MaterielsClass_Id");
            AddForeignKey("dbo.Materiels", "MaterielsClass_Id", "dbo.MaterielsClasses", "Id");
            MoveTable(name: "Basic.Materiels", newSchema: "dbo");
        }
    }
}
