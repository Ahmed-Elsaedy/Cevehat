namespace Cevehat.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appliedUserJunktionTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplayedUsers", "JobVacancie_JobVacancieID", "dbo.JobVacancies");
            DropIndex("dbo.ApplayedUsers", new[] { "JobVacancie_JobVacancieID" });
            RenameColumn(table: "dbo.ApplayedUsers", name: "JobVacancie_JobVacancieID", newName: "JobVacancieID");
            AlterColumn("dbo.ApplayedUsers", "JobVacancieID", c => c.Int(nullable: false));
            CreateIndex("dbo.ApplayedUsers", "JobVacancieID");
            AddForeignKey("dbo.ApplayedUsers", "JobVacancieID", "dbo.JobVacancies", "JobVacancieID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplayedUsers", "JobVacancieID", "dbo.JobVacancies");
            DropIndex("dbo.ApplayedUsers", new[] { "JobVacancieID" });
            AlterColumn("dbo.ApplayedUsers", "JobVacancieID", c => c.Int());
            RenameColumn(table: "dbo.ApplayedUsers", name: "JobVacancieID", newName: "JobVacancie_JobVacancieID");
            CreateIndex("dbo.ApplayedUsers", "JobVacancie_JobVacancieID");
            AddForeignKey("dbo.ApplayedUsers", "JobVacancie_JobVacancieID", "dbo.JobVacancies", "JobVacancieID");
        }
    }
}
