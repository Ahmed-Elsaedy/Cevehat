namespace Cevehat.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompaniesData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "CompanyPhone", c => c.String());
            AddColumn("dbo.Companies", "CompanyInfo", c => c.String());
            AddColumn("dbo.Companies", "CompanyEmail", c => c.String());
            AddColumn("dbo.Companies", "CompanyImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "CompanyImage");
            DropColumn("dbo.Companies", "CompanyEmail");
            DropColumn("dbo.Companies", "CompanyInfo");
            DropColumn("dbo.Companies", "CompanyPhone");
        }
    }
}
