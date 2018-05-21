namespace BM.WMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Materielsclassupdate : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.MaterielsClasses", newSchema: "Basic");
            AlterColumn("Basic.MaterielsClasses", "ClassName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("Basic.MaterielsClasses", "Remark", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("Basic.MaterielsClasses", "Remark", c => c.String());
            AlterColumn("Basic.MaterielsClasses", "ClassName", c => c.String(nullable: false));
            MoveTable(name: "Basic.MaterielsClasses", newSchema: "dbo");
        }
    }
}
