namespace JoinPlan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Participation",
                c => new
                    {
                        ParticipationID = c.Int(nullable: false, identity: true),
                        ActivityID = c.Int(nullable: false),
                        ParticipantEmail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ParticipationID)
                .ForeignKey("dbo.Activity", t => t.ActivityID, cascadeDelete: true)
                .Index(t => t.ActivityID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Participation", "ActivityID", "dbo.Activity");
            DropIndex("dbo.Participation", new[] { "ActivityID" });
            DropTable("dbo.Participation");
        }
    }
}
