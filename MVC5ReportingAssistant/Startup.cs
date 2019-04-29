using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Cookies;
using MVC5ReportingAssistant.Identity;

[assembly: OwinStartup(typeof(MVC5ReportingAssistant.Startup))]

namespace MVC5ReportingAssistant
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            CreateUsersAndRoles();
        }

        public void CreateUsersAndRoles()
        {
            //Creating role Admin
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var db = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(db);
            var userManager = new ApplicationUserManager(userStore);

            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }

            //Adding admin George
            if (userManager.FindByName("George") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "George";
                user.Email = "george@test.com";
                var password = "George1";
                var checkUser = userManager.Create(user, password);

                if (checkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            //Adding admin John
            if (userManager.FindByName("John") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "John";
                user.Email = "john@test.com";
                var password = "John123";

                var checkUser = userManager.Create(user, password);

                if (checkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            //Adding admin Mary
            if (userManager.FindByName("Mary") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "Mary";
                user.Email = "mary@test.com";
                string password = "Mary123";
                var checkUser = userManager.Create(user, password);

                if (checkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                    userManager.AddToRole(user.Id, "User");
                }
            }

            //Creating User role
            if (!roleManager.RoleExists("User"))
            {
                roleManager.Create(new IdentityRole("User"));
            }

            //Creating user Sam
            if (userManager.FindByName("Sam") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "Sam";
                user.Email = "sam@test.com";
                string password = "Sam1234";

                var checkUser = userManager.Create(user, password);

                if (checkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "User");
                }
            }

            //Creating user Ben
            if (userManager.FindByName("Ben") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "Ben";
                user.Email = "ben@test.com";
                string password = "Ben1234";

                var checkUser = userManager.Create(user, password);

                if (checkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "User");
                }
            }

            //Creating user Ann
            if (userManager.FindByName("Ann") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "Ann";
                user.Email = "ann@test.com";
                string password = "Ann1234";

                var checkUser = userManager.Create(user, password);

                if (checkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "User");
                }
            }
        }
    }
}
