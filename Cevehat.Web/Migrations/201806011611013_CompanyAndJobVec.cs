namespace Cevehat.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyAndJobVec : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyWebSite = c.String(),
                    })
                .PrimaryKey(t => t.CompanyID);
            
            CreateTable(
                "dbo.JobRequirements",
                c => new
                    {
                        ReqID = c.Int(nullable: false, identity: true),
                        ReqText = c.String(),
                        JobVacID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReqID)
                .ForeignKey("dbo.JobVacancies", t => t.JobVacID, cascadeDelete: true)
                .Index(t => t.JobVacID);
            
            CreateTable(
                "dbo.JobVacancies",
                c => new
                    {
                        JobVacancieID = c.Int(nullable: false, identity: true),
                        ExpYears = c.Int(nullable: false),
                        JobTitleID = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        JobType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobVacancieID)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .ForeignKey("dbo.JobTitles", t => t.JobTitleID, cascadeDelete: true)
                .Index(t => t.JobTitleID)
                .Index(t => t.CompanyID);
            
            AddColumn("dbo.Skills", "JobVacancie_JobVacancieID", c => c.Int());
            CreateIndex("dbo.Skills", "JobVacancie_JobVacancieID");
            AddForeignKey("dbo.Skills", "JobVacancie_JobVacancieID", "dbo.JobVacancies", "JobVacancieID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobRequirements", "JobVacID", "dbo.JobVacancies");
            DropForeignKey("dbo.Skills", "JobVacancie_JobVacancieID", "dbo.JobVacancies");
            DropForeignKey("dbo.JobVacancies", "JobTitleID", "dbo.JobTitles");
            DropForeignKey("dbo.JobVacancies", "CompanyID", "dbo.Companies");
            DropIndex("dbo.JobVacancies", new[] { "CompanyID" });
            DropIndex("dbo.JobVacancies", new[] { "JobTitleID" });
            DropIndex("dbo.JobRequirements", new[] { "JobVacID" });
            DropIndex("dbo.Skills", new[] { "JobVacancie_JobVacancieID" });
            DropColumn("dbo.Skills", "JobVacancie_JobVacancieID");
            DropTable("dbo.JobVacancies");
            DropTable("dbo.JobRequirements");
            DropTable("dbo.Companies");
        }
    }
}
