namespace Cevehat.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppUserModifications : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "Summary", c => c.String());
            AddColumn("dbo.AspNetUsers", "FacebookUrl", c => c.String());
            AddColumn("dbo.AspNetUsers", "TwitterUrl", c => c.String());
            AddColumn("dbo.AspNetUsers", "LinkinUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LinkinUrl");
            DropColumn("dbo.AspNetUsers", "TwitterUrl");
            DropColumn("dbo.AspNetUsers", "FacebookUrl");
            DropColumn("dbo.AspNetUsers", "Summary");
            DropColumn("dbo.AspNetUsers", "Address");
        }
    }
}
