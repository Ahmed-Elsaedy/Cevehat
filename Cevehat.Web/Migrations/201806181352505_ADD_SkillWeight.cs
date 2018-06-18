namespace Cevehat.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADD_SkillWeight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobTitles_Skills", "SkillWeight", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobTitles_Skills", "SkillWeight");
        }
    }
}
