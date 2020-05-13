using JoinPlan.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JoinPlan.Controllers
{
    public class UsersController : ApiController
    {

        public class UserInfo
        {
            [Required]
            public string DisplayName { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public string Role { get; set; }
            [Display(Name = "Last Login"),
             DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
            [DataType(DataType.DateTime)]
            [Required]
            public DateTime LastLogin { get; set; }
        }

        private static ApplicationDbContext userContext = new ApplicationDbContext();
        private static RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(userContext));
        private static ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(userContext));
        public IHttpActionResult Get()
        {
            List<UserInfo> userInfo = new List<UserInfo>();
            var users = userContext.Users.ToList().Where(u => roleManager.FindById(u.Roles.ElementAt(0).RoleId).Name == "member");

            foreach ( var user in users)
            {
                userInfo.Add(new UserInfo
                {
                    DisplayName = user.DisplayName,
                    LastLogin = user.LastLogin,
                    Email   = user.Email,
                    Role = roleManager.FindById(user.Roles.ElementAt(0).RoleId).Name,
                });
            }

            return this.Content(HttpStatusCode.OK, new { success = true, users = userInfo });
        }

        public IHttpActionResult Delete(string email) 
        {
            var user = userManager.FindByEmail(email);
            if (user != null)
            {
                try
                {
                    userManager.Delete(user);
                    return this.Content(HttpStatusCode.OK, new { success = true });
                }
                catch(Exception e)
                {
                    return this.Content(HttpStatusCode.OK, new { success = false, error = e.Message });
                }

            }
            else
            {
                return this.Content(HttpStatusCode.OK, new { success = false, error = "No such user exist" });
            }
        }
    }
}
