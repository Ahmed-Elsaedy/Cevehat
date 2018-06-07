namespace Cevehat.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _662018440 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobTitles", "SkillCount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobTitles", "SkillCount");
        }
    }
}
