using JoinPlan.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(JoinPlan.Startup))]
namespace JoinPlan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesAndUsers();
        }

        private readonly string[] USER_ROLES = new string[] { "admin", "member" };
        private readonly string DEFAULT_ADMIN_EMAIL = "admin@joinplan.my";
        private readonly string DEFAULT_ADMIN_NAME = "admin";
        private readonly string DEFAULT_ADMIN_PW = "Admin@123";

        private readonly string DEFAULT_MEMBER_EMAIL = "member1@joinplan.my";
        private readonly string DEFAULT_MEMBER_NAME = "member_test";
        private readonly string DEFAULT_MEMBER_PW = "Test@123";

        private async void createRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            //UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            foreach (var role in USER_ROLES)
            {
                if (!roleManager.RoleExists(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            ApplicationUser defaultAdminUser = await userManager.FindByEmailAsync(DEFAULT_ADMIN_EMAIL);
            if (defaultAdminUser == null)
            {
                System.Diagnostics.Debug.WriteLine("No default admin user found");
                var newDefaultAdminUser = new ApplicationUser {
                    UserName = DEFAULT_ADMIN_EMAIL,
                    Email = DEFAULT_ADMIN_EMAIL,
                    DisplayName = DEFAULT_ADMIN_NAME,
                    LastLogin = DateTime.Now
                };

                var res = await userManager.CreateAsync(newDefaultAdminUser, DEFAULT_ADMIN_PW);
                
                if (res.Succeeded)
                {
                    System.Diagnostics.Debug.WriteLine("Create default admin user succeeded");
                    await userManager.AddToRoleAsync(newDefaultAdminUser.Id, USER_ROLES[0]);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Create default admin user failed");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Default admin user found");
            }

            ApplicationUser dummyMember = await userManager.FindByEmailAsync(DEFAULT_MEMBER_EMAIL);
            if (dummyMember == null)
            {
                System.Diagnostics.Debug.WriteLine("No dummy member user found");
                var newDefaultAdminUser = new ApplicationUser
                {
                    UserName = DEFAULT_MEMBER_EMAIL,
                    Email = DEFAULT_MEMBER_EMAIL,
                    DisplayName = DEFAULT_MEMBER_NAME,
                    LastLogin = DateTime.Now
                };

                var res = await userManager.CreateAsync(newDefaultAdminUser, DEFAULT_MEMBER_PW);

                if (res.Succeeded)
                {
                    System.Diagnostics.Debug.WriteLine("Create dummy member user succeeded");
                    await userManager.AddToRoleAsync(newDefaultAdminUser.Id, USER_ROLES[1]);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Create dummy member user failed");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Default admin user found");
            }
        }

    }
}
