namespace Cevehat.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finalCompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobVacancies", "Requirements", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobVacancies", "Requirements");
        }
    }
}
