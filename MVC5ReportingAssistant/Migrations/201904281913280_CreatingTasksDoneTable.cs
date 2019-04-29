namespace MVC5ReportingAssistant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingTasksDoneTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TasksDones",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        Screen = c.String(maxLength: 50),
                        Description = c.String(),
                        UserId = c.String(maxLength: 128),
                        DateOfTaskDone = c.DateTime(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TasksDones", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.TasksDones", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.TasksDones", new[] { "ProjectId" });
            DropIndex("dbo.TasksDones", new[] { "UserId" });
            DropTable("dbo.TasksDones");
        }
    }
}
