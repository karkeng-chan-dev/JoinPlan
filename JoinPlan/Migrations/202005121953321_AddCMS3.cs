namespace JoinPlan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCMS3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CMS", "Type", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CMS", "Type");
        }
    }
}
