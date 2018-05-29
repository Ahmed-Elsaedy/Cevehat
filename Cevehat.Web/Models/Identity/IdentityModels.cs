using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Cevehat.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public partial class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public virtual DbSet<CareerObjective> CareerObjective { get; set; }
        public virtual DbSet<Certification> Certification { get; set; }
        public virtual DbSet<Education> Education { get; set; }

        public virtual DbSet<Experince> Experinces { get; set; }
        public virtual DbSet<InterviewQustion> InterviewQustion { get; set; }
        public virtual DbSet<JobTitle> JobTitle { get; set; }
        public virtual DbSet<JobTitles_Skills> JobTitles_Skills { get; set; }
        public virtual DbSet<Skills> Skill { get; set; }
        public virtual DbSet<SoftSkill> Skills { get; set; }






        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }





    }
}