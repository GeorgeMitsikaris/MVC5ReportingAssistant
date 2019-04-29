namespace MVC5ReportingAssistant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingFianlCommentsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FinalComments",
                c => new
                    {
                        FinalCommentID = c.Int(nullable: false, identity: true),
                        Screen = c.String(maxLength: 50),
                        Description = c.String(),
                        AdminUserId = c.String(maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        DateOfFinalComment = c.DateTime(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FinalCommentID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.AdminUserId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.AdminUserId)
                .Index(t => t.UserId)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FinalComments", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.FinalComments", "AdminUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FinalComments", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.FinalComments", new[] { "ProjectId" });
            DropIndex("dbo.FinalComments", new[] { "UserId" });
            DropIndex("dbo.FinalComments", new[] { "AdminUserId" });
            DropTable("dbo.FinalComments");
        }
    }
}
