namespace JoinPlan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFeedbackModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feedback", "Read", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Feedback", "Subject", c => c.String(nullable: false));
            AlterColumn("dbo.Feedback", "Body", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Feedback", "Body", c => c.String());
            AlterColumn("dbo.Feedback", "Subject", c => c.String());
            DropColumn("dbo.Feedback", "Read");
        }
    }
}
