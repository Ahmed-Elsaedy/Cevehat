namespace Cevehat.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sec : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CareerObjectives",
                c => new
                    {
                        CareerId = c.Int(nullable: false, identity: true),
                        CareerText = c.String(),
                        JobID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CareerId)
                .ForeignKey("dbo.JobTitles", t => t.JobID, cascadeDelete: true)
                .Index(t => t.JobID);
            
            CreateTable(
                "dbo.JobTitles",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        JobName = c.String(),
                    })
                .PrimaryKey(t => t.JobId);
            
            CreateTable(
                "dbo.InterviewQustions",
                c => new
                    {
                        QID = c.Int(nullable: false, identity: true),
                        Qbody = c.String(),
                        QAns = c.String(),
                        jobTitleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QID)
                .ForeignKey("dbo.JobTitles", t => t.jobTitleID, cascadeDelete: true)
                .Index(t => t.jobTitleID);
            
            CreateTable(
                "dbo.Certifications",
                c => new
                    {
                        Cerid = c.Int(nullable: false, identity: true),
                        CerPlace = c.String(),
                        CerName = c.String(),
                        CerYear = c.DateTime(nullable: false),
                        userid = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Cerid)
                .ForeignKey("dbo.AspNetUsers", t => t.userid)
                .Index(t => t.userid);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Fname = c.String(),
                        Lname = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        MaritaSutes = c.Int(nullable: false),
                        MilitaryStatus = c.Int(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        EducationId = c.Int(nullable: false, identity: true),
                        GPA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GradYear = c.DateTime(nullable: false),
                        DepartmentName = c.String(),
                        OrganizationName = c.String(),
                        userId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EducationId)
                .ForeignKey("dbo.AspNetUsers", t => t.userId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.Experinces",
                c => new
                    {
                        ExpId = c.Int(nullable: false, identity: true),
                        Place = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Position = c.String(),
                        Responsbilty = c.String(),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ExpId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SoftSkills",
                c => new
                    {
                        SoftSkillsID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        userid = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SoftSkillsID)
                .ForeignKey("dbo.AspNetUsers", t => t.userid)
                .Index(t => t.userid);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Skill_Id = c.Int(nullable: false, identity: true),
                        Skill_name = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Skill_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.JobTitles_Skills",
                c => new
                    {
                        Skill_ID = c.Int(nullable: false),
                        JbTitle_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Skill_ID, t.JbTitle_ID })
                .ForeignKey("dbo.JobTitles", t => t.JbTitle_ID, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.Skill_ID, cascadeDelete: true)
                .Index(t => t.Skill_ID)
                .Index(t => t.JbTitle_ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.JobTitles_Skills", "Skill_ID", "dbo.Skills");
            DropForeignKey("dbo.JobTitles_Skills", "JbTitle_ID", "dbo.JobTitles");
            DropForeignKey("dbo.Certifications", "userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.Skills", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SoftSkills", "userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Experinces", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Educations", "userId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CareerObjectives", "JobID", "dbo.JobTitles");
            DropForeignKey("dbo.InterviewQustions", "jobTitleID", "dbo.JobTitles");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.JobTitles_Skills", new[] { "JbTitle_ID" });
            DropIndex("dbo.JobTitles_Skills", new[] { "Skill_ID" });
            DropIndex("dbo.Skills", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SoftSkills", new[] { "userid" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Experinces", new[] { "UserID" });
            DropIndex("dbo.Educations", new[] { "userId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Certifications", new[] { "userid" });
            DropIndex("dbo.InterviewQustions", new[] { "jobTitleID" });
            DropIndex("dbo.CareerObjectives", new[] { "JobID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.JobTitles_Skills");
            DropTable("dbo.Skills");
            DropTable("dbo.SoftSkills");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Experinces");
            DropTable("dbo.Educations");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Certifications");
            DropTable("dbo.InterviewQustions");
            DropTable("dbo.JobTitles");
            DropTable("dbo.CareerObjectives");
        }
    }
}
