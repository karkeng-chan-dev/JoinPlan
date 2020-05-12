namespace JoinPlan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        ActivityID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ImageUrl = c.String(nullable: false),
                        OrganizerEmail = c.String(nullable: false),
                        ActivityDateTime = c.DateTime(nullable: false),
                        MaxParticipant = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityID);
            
            CreateTable(
                "dbo.ActivityUpdate",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        PublishedDateTime = c.DateTime(nullable: false),
                        ActivityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Activity", t => t.ActivityID, cascadeDelete: true)
                .Index(t => t.ActivityID);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        FeedbackID = c.Int(nullable: false, identity: true),
                        MemberEmail = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        FeedbackDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FeedbackID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActivityUpdate", "ActivityID", "dbo.Activity");
            DropIndex("dbo.ActivityUpdate", new[] { "ActivityID" });
            DropTable("dbo.Feedback");
            DropTable("dbo.ActivityUpdate");
            DropTable("dbo.Activity");
        }
    }
}
