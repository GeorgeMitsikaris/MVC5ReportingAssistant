namespace MVC5ReportingAssistant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDatetimeColumnNameOfTasksTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "DateOfTask", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tasks", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "MyProperty", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tasks", "DateOfTask");
        }
    }
}
