using System;
using Cevehat.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cevehat.Web.Startup))]
namespace Cevehat.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        ApplicationDbContext context;
        private void createRolesandUsers()
        {
             context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //In Startup iam creating first Admin Role and creating a default Admin User
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin role   
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = "asmaa";
                user.Email = "asmaa@gmail.com";

                string userPWD = "As@123456";

                var checkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (checkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);

            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);

            }

            // creating Creating Employer role    
            if (!roleManager.RoleExists("Employer"))
            {
                var role = new IdentityRole();
                role.Name = "Employer";
                roleManager.Create(role);
                
            }
        }
    }
}
