namespace Cevehat.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skills : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SoftSkills", "userid", "dbo.AspNetUsers");
            DropIndex("dbo.SoftSkills", new[] { "userid" });
            RenameColumn(table: "dbo.Skills", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Skills", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
            AddColumn("dbo.Skills", "Title", c => c.String());
            AddColumn("dbo.Skills", "Description", c => c.String());
            DropColumn("dbo.Skills", "Skill_name");
            //DropTable("dbo.SoftSkills");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SoftSkills",
                c => new
                    {
                        SoftSkillsID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        userid = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SoftSkillsID);
            
            AddColumn("dbo.Skills", "Skill_name", c => c.String());
            DropColumn("dbo.Skills", "Description");
            DropColumn("dbo.Skills", "Title");
            RenameIndex(table: "dbo.Skills", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Skills", name: "UserId", newName: "ApplicationUser_Id");
            CreateIndex("dbo.SoftSkills", "userid");
            AddForeignKey("dbo.SoftSkills", "userid", "dbo.AspNetUsers", "Id");
        }
    }
}
