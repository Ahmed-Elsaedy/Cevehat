namespace Cevehat.Web.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CVhatDb : DbContext
    {
        // Your context has been configured to use a 'DbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Cevehat.Web.Models.DbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DbContext' 
        // connection string in the application configuration file.
        public CVhatDb()
            : base("name=CVhatDb")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }
        public virtual DbSet<CareerObjective> CareerObjective { get; set; }
        public virtual DbSet<Certification>  Certification { get; set; }
        public virtual DbSet<Education>   Education  { get; set; }
        public virtual DbSet<Experince>  Experince { get; set; }
        public virtual DbSet<InterviewQustion> InterviewQustion  { get; set; }
        public virtual DbSet<JobTitle> JobTitle  { get; set; }
        public virtual DbSet<JobTitles_Skills> JobTitles_Skill  { get; set; }
        public virtual DbSet<Skill>  Skill { get; set; }
        public virtual DbSet<SoftSkill>  SoftSkills { get; set; }










}

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}