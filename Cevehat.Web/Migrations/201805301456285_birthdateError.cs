namespace Cevehat.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class birthdateError : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "BirthDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
