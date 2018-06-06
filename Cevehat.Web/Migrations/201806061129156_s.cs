namespace Cevehat.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Educations", "StartYear", c => c.DateTime(nullable: false));
            AddColumn("dbo.Educations", "DegreeTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Educations", "DegreeTitle");
            DropColumn("dbo.Educations", "StartYear");
        }
    }
}
