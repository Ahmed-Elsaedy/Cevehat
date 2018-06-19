namespace Cevehat.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userlogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LastLogin", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LastLogin");
        }
    }
}
