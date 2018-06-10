namespace Cevehat.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Commitallchanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Skills", "JobVacancie_JobVacancieID", "dbo.JobVacancies");
            DropIndex("dbo.Skills", new[] { "JobVacancie_JobVacancieID" });
            CreateTable(
                "dbo.JobVacancieSkills",
                c => new
                    {
                        JobVacancie_JobVacancieID = c.Int(nullable: false),
                        Skill_Skill_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobVacancie_JobVacancieID, t.Skill_Skill_Id })
                .ForeignKey("dbo.JobVacancies", t => t.JobVacancie_JobVacancieID, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.Skill_Skill_Id, cascadeDelete: true)
                .Index(t => t.JobVacancie_JobVacancieID)
                .Index(t => t.Skill_Skill_Id);

            AddColumn("dbo.Experinces", "IsPresent", c => c.Boolean(nullable: false));

        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "JobVacancie_JobVacancieID", c => c.Int());
            DropForeignKey("dbo.JobVacancieSkills", "Skill_Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.JobVacancieSkills", "JobVacancie_JobVacancieID", "dbo.JobVacancies");
            DropIndex("dbo.JobVacancieSkills", new[] { "Skill_Skill_Id" });
            DropIndex("dbo.JobVacancieSkills", new[] { "JobVacancie_JobVacancieID" });
            DropTable("dbo.JobVacancieSkills");
            CreateIndex("dbo.Skills", "JobVacancie_JobVacancieID");
            AddForeignKey("dbo.Skills", "JobVacancie_JobVacancieID", "dbo.JobVacancies", "JobVacancieID");
        }
    }
}
