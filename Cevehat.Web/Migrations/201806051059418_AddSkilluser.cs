namespace Cevehat.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSkilluser : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Skills", name: "UserId", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Skills", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            CreateTable(
                "dbo.User_Skills",
                c => new
                    {
                        User_Skills_ID = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        SkillID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.User_Skills_ID)
                .ForeignKey("dbo.Skills", t => t.SkillID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.SkillID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_Skills", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.User_Skills", "SkillID", "dbo.Skills");
            DropIndex("dbo.User_Skills", new[] { "SkillID" });
            DropIndex("dbo.User_Skills", new[] { "UserId" });
            DropTable("dbo.User_Skills");
            RenameIndex(table: "dbo.Skills", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.Skills", name: "ApplicationUser_Id", newName: "UserId");
        }
    }
}
