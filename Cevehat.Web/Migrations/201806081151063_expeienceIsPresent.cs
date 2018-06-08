namespace Cevehat.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expeienceIsPresent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Experinces", "IsPresent", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Experinces", "IsPresent");
        }
    }
}
