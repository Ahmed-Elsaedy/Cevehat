namespace Cevehat.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skillweight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobTitles_Skills", "Weight", c => c.Int(nullable: false));
            AddColumn("dbo.User_Skills", "Weight", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User_Skills", "Weight");
            DropColumn("dbo.JobTitles_Skills", "Weight");
        }
    }
}
