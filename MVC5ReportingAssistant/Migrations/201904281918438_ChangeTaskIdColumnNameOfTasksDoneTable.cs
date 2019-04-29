namespace MVC5ReportingAssistant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTaskIdColumnNameOfTasksDoneTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TasksDones");
            DropColumn("dbo.TasksDones", "TaskId");
            AddColumn("dbo.TasksDones", "TaskDoneId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TasksDones", "TaskDoneId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TasksDones", "TaskId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TasksDones", "TaskId");
            DropPrimaryKey("dbo.TasksDones");
            DropColumn("dbo.TasksDones", "TaskDoneId");
        }
    }
}
