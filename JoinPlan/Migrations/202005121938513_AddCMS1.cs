namespace JoinPlan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCMS1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CMS",
                c => new
                    {
                        CmsID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CmsID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CMS");
        }
    }
}
